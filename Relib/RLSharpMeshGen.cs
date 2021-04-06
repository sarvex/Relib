using System;
using System.Collections.Generic;
using System.Numerics;

using System.Runtime.InteropServices;

namespace RLSharpMeshGen
{
    public static class RayLibMemory
    {
        // Used by DllImport to load the native library.
        public const string nativeLibName = "raylib";
        public const string RAYLIB_VERSION = "3.5";

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MemAlloc(int size);  // Internal memory allocator

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MemFree(IntPtr ptr);   // Internal memory free
    }

    public class MeshBuilder
    {
        private float[] FloatBuffer = new float[4];
        private short[] ShortBuffer = new short[3];
        private byte[] ByteBuffer = new byte[4];

        protected int VertIndex = 0;

        public Raylib_cs.Mesh Mesh;

        public MeshBuilder()
        {
            Mesh = new Raylib_cs.Mesh();

            Mesh.vertexCount = 0;
            Mesh.triangleCount =0;
            Mesh.vertices = IntPtr.Zero;
            Mesh.normals = IntPtr.Zero;
            Mesh.indices = IntPtr.Zero;
            Mesh.texcoords = IntPtr.Zero;
            Mesh.texcoords2 = IntPtr.Zero;
            Mesh.tangents = IntPtr.Zero;
            Mesh.colors = IntPtr.Zero;

            Mesh.animNormals = IntPtr.Zero;
            Mesh.animVertices = IntPtr.Zero;
            Mesh.boneIds = IntPtr.Zero;
            Mesh.boneWeights = IntPtr.Zero;

            Mesh.vboId = RayLibMemory.MemAlloc(4 * 6);
            Mesh.vaoId = 0;
        }

        public MeshBuilder(Raylib_cs.Mesh mesh)
        {
            Mesh = mesh;
            VertIndex = mesh.vertexCount;
        }

        public void Begin(int triangles, bool colors, bool uvs, bool uv2s)
        {
            if (Bound())
                Raylib_cs.Rlgl.rlUnloadMesh(Mesh);

            VertIndex = 0;

            int verts = triangles * 3;

            Mesh.vertices = RayLibMemory.MemAlloc(verts * 3 * sizeof(float));
            Mesh.normals = RayLibMemory.MemAlloc(verts * 3 * sizeof(float));

            if (uvs)
                Mesh.texcoords = RayLibMemory.MemAlloc(verts * 2 * sizeof(float));
            else
                Mesh.texcoords = IntPtr.Zero;

            if (uv2s)
                Mesh.texcoords2 = RayLibMemory.MemAlloc(verts * 2 * sizeof(float));
            else
                Mesh.texcoords2 = IntPtr.Zero;

            if (colors)
                Mesh.colors = RayLibMemory.MemAlloc(verts * 4);
            else
                Mesh.colors = IntPtr.Zero;

            Mesh.animNormals = IntPtr.Zero;
            Mesh.animVertices = IntPtr.Zero;
            Mesh.boneIds = IntPtr.Zero;
            Mesh.boneWeights = IntPtr.Zero;

            Mesh.indices = RayLibMemory.MemAlloc(triangles * 3 * sizeof(short));
            Mesh.vertexCount = verts;
            Mesh.triangleCount = triangles;
        }

        public bool Bound()
        {
            return Mesh.vaoId > 0 && Mesh.vertices != IntPtr.Zero;
        }

        public void Bind()
        {
            if (!Bound())
                Raylib_cs.Rlgl.rlLoadMesh(ref Mesh, false);
        }

        private void InsertVector3(ref Vector3 vec, ref IntPtr dest)
        {
            vec.CopyTo(FloatBuffer);
            Marshal.Copy(FloatBuffer, 0, dest, 3);
            dest += 4 * 3;
        }

        private void InsertVector2(ref Vector2 vec, ref IntPtr dest)
        {
            vec.CopyTo(FloatBuffer);
            Marshal.Copy(FloatBuffer, 0, dest, 2);
            dest += 4 * 2;
        }

        private void InsertColor(ref Raylib_cs.Color color, ref IntPtr dest)
        {
            ByteBuffer[0] = color.r;
            ByteBuffer[1] = color.g;
            ByteBuffer[2] = color.b;
            ByteBuffer[3] = color.a;

            Marshal.Copy(ByteBuffer, 0, dest, 4);
            dest += 4;
        }

        public void AddTriangle(Vector3 aVert, Vector3 aNormal, Vector2 aUV,
                               Vector3 bVert, Vector3 bNormal, Vector2 bUV,
                               Vector3 cVert, Vector3 cNormal, Vector2 cUV)
        {
            IntPtr vertInsert = Mesh.vertices + (VertIndex * 4 * 3);
            IntPtr normInsert = Mesh.normals + (VertIndex * 4 * 3);
            IntPtr uvInsert = Mesh.texcoords + (VertIndex * 4 * 2);

            IntPtr indexInsert = Mesh.indices + (VertIndex * 2);

            InsertVector3(ref aVert, ref vertInsert);
            InsertVector3(ref bVert, ref vertInsert);
            InsertVector3(ref cVert, ref vertInsert);

            InsertVector3(ref aNormal, ref normInsert);
            InsertVector3(ref bNormal, ref normInsert);
            InsertVector3(ref cNormal, ref normInsert);

            InsertVector2(ref aUV, ref uvInsert);
            InsertVector2(ref bUV, ref uvInsert);
            InsertVector2(ref cUV, ref uvInsert);

            ShortBuffer[0] = (short)(VertIndex);
            ShortBuffer[1] = (short)(VertIndex+1);
            ShortBuffer[2] = (short)(VertIndex+2);

            Marshal.Copy(ShortBuffer, 0, indexInsert, 3);

            VertIndex += 3;
        }

        public void AddTriangle(Vector3 aVert, Vector3 aNormal, Vector2 aUV, Vector2 aUV2,
                            Vector3 bVert, Vector3 bNormal, Vector2 bUV, Vector2 bUV2,
                            Vector3 cVert, Vector3 cNormal, Vector2 cUV, Vector2 cUV2)
        {

            int startIndex = VertIndex;
            AddTriangle(aVert, aNormal, aUV, bVert, bNormal, bUV, cVert, cNormal, cUV);

            IntPtr uv2Insert = Mesh.texcoords2 + (startIndex * 4 * 2);

            InsertVector2(ref aUV2, ref uv2Insert);
            InsertVector2(ref bUV2, ref uv2Insert);
            InsertVector2(ref cUV2, ref uv2Insert);
        }

        public void AddTriangle(Vector3 aVert, Vector3 aNormal, Vector2 aUV, Vector2 aUV2, Raylib_cs.Color aColor,
                                Vector3 bVert, Vector3 bNormal, Vector2 bUV, Vector2 bUV2, Raylib_cs.Color bColor,
                                Vector3 cVert, Vector3 cNormal, Vector2 cUV, Vector2 cUV2, Raylib_cs.Color cColor)
        {
            int startIndex = VertIndex;
            AddTriangle(aVert, aNormal, aUV, aUV2, bVert, bNormal, bUV, bUV2, cVert, cNormal, cUV,cUV2);

            IntPtr colorInsert = Mesh.colors + (startIndex * 4);

            InsertColor(ref aColor, ref colorInsert);
            InsertColor(ref bColor, ref colorInsert);
            InsertColor(ref cColor, ref colorInsert);
        }


        public int Triangles { get { return Mesh.triangleCount; } }
        
        public bool GetTriangleIndecies(int index, ref short a, ref short b , ref short c)
        {
            if (index >= Mesh.triangleCount)
                return false;

            short[] indexes = new short[3];

            IntPtr offset = Mesh.indices + (index * 2 * 3);
            Marshal.Copy(offset, indexes, 0, 3);
            a = indexes[0];
            b = indexes[1];
            c = indexes[2];

            return true;
        }

        public Vector3 GetVertex(int index)
        {
            if (index >= Mesh.vertexCount)
                return new Vector3(float.MinValue,float.MinValue,float.MinValue);

            float[] values = new float[3];

            IntPtr offset = Mesh.vertices + (index * 4 * 3);
            Marshal.Copy(offset, values, 0, 3);
            return new Vector3(values[0], values[1], values[2]);
        }

        public Vector3 GetNormal(int index)
        {
            if (index >= Mesh.vertexCount)
                return new Vector3(float.MinValue, float.MinValue, float.MinValue);

            float[] values = new float[3];

            IntPtr offset = Mesh.normals + (index * 4 * 3);
            Marshal.Copy(offset, values, 0, 3);
            return new Vector3(values[0], values[1], values[2]);
        }

        public Vector2 GetUV(int index)
        {
            if (index >= Mesh.vertexCount || Mesh.texcoords == IntPtr.Zero)
                return new Vector2(float.MinValue, float.MinValue);

            float[] values = new float[2];

            IntPtr offset = Mesh.texcoords + (index * 4 * 2);
            Marshal.Copy(offset, values, 0, 3);
            return new Vector2(values[0], values[1]);
        }

        public Vector2 GetUV2(int index)
        {
            if (index >= Mesh.vertexCount || Mesh.texcoords2 == IntPtr.Zero)
                return new Vector2(float.MinValue, float.MinValue);

            float[] values = new float[2];

            IntPtr offset = Mesh.texcoords2 + (index * 4 * 2);
            Marshal.Copy(offset, values, 0, 3);
            return new Vector2(values[0], values[1]);
        }
    }
}