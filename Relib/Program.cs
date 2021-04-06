using System;
using System.IO;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using Raylib_cs;
using System.Linq;
using System.Reflection;
using snv3 = System.Numerics.Vector3;
using snv2 = System.Numerics.Vector2;
using rlv3 = Relib.Relib.Vector3;
using rlv2 = Relib.Relib.Vector2;
using col = Relib.Relib.Color;
using co = Raylib_cs.Color;

namespace Relib
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public static class Relib
    {
        public static void CD(string path) => Directory.SetCurrentDirectory(path);
        public static float SIN(float a) => (float)Math.Sin(a);
        public static float COS(float a) => (float)Math.Cos(a);
        public static float TAN(float a) => (float)Math.Tan(a);
        public static float ASIN(float a) => (float)Math.Asin(a);
        public static float ACOS(float a) => (float)Math.Acos(a);
        public static float ATAN(float a) => (float)Math.Atan(a);
        public static float DEGTORAD(float a) => a * 0.017453f;
        
        public static void InitWindow(int w, int h, string name) => Raylib.InitWindow(w, h, name);
        public static bool WindowShouldClose() => Raylib.WindowShouldClose();
        public static void CloseWindow() => Raylib.CloseWindow();
        public static bool IsWindowReady() => Raylib.IsWindowReady();
        public static bool IsWindowFullscreen() => Raylib.IsWindowFullscreen();
        public static bool IsWindowHidden() => Raylib.IsWindowHidden();
        public static bool IsWindowMinimized() => Raylib.IsWindowMinimized();
        public static bool IsWindowMaximized() => Raylib.IsWindowMaximized();
        public static bool IsWindowFocused() => Raylib.IsWindowFocused();
        public static bool IsWindowResized() => Raylib.IsWindowResized();
        public static bool IsWindowState(int flags) => Raylib.IsWindowState((ConfigFlag)flags);
        public static bool SetWindowState(int flags) => Raylib.SetWindowState((ConfigFlag)flags);
        public static void ClearWindowState(int flags) => Raylib.ClearWindowState((ConfigFlag)flags);
        public static void ToggleFullscreen() => Raylib.ToggleFullscreen();
        public static void MaximizeWindow() => Raylib.MaximizeWindow();
        public static void MinimizeWindow() => Raylib.MinimizeWindow();
        public static void RestoreWindow() => Raylib.RestoreWindow();
        public static void SetWindowIcon(Image img) => Raylib.SetWindowIcon((Raylib_cs.Image)img.GetSource());
        public static void SetWindowTitle(string title) => Raylib.SetWindowTitle(title);
        public static void SetWindowPosition(int x, int y) => Raylib.SetWindowPosition(x, y);
        public static void SetWindowMonitor(int mon) => Raylib.SetWindowMonitor(mon);
        public static void SetWindowMinSize(int w, int h) => Raylib.SetWindowMinSize(w, h);
        public static void SetWindowSize(int w, int h) => Raylib.SetWindowSize(w, h);
        public static int GetScreenWidth() => Raylib.GetScreenWidth();
        public static int GetScreenHeight() => Raylib.GetScreenHeight();
        public static int GetMonitorCount() => Raylib.GetMonitorCount();
        public static Vector2 GetMonitorPosition() => RLV2TOV2(Raylib.GetMonitorPosition());
        public static int GetMonitorWidth(int mon) => Raylib.GetMonitorWidth(mon);
        public static int GetMonitorHeight(int mon) => Raylib.GetMonitorHeight(mon);
        public static int GetMonitorPhysicalWidth(int mon) => Raylib.GetMonitorPhysicalWidth(mon);
        public static int GetMonitorPhysicalHeight(int mon) => Raylib.GetMonitorPhysicalHeight(mon);
        public static int GetMonitorRefreshRate(int mon) => Raylib.GetMonitorRefreshRate(mon);
        public static Vector2 GetWindowPosition() => RLV2TOV2(Raylib.GetWindowPosition());
        public static Vector2 GetWindowScaleDPI() => RLV2TOV2(Raylib.GetWindowScaleDPI());
        public static string GetMonitorName(int mon) => Raylib.GetMonitorName(mon);
        public static void SetClipboardText(string text) => Raylib.SetClipboardText(text);
        public static string GetClipboardText() => Raylib.GetClipboardText();
        
        // Cursor-related functions         
        public static void ShowCursor() => Raylib.ShowCursor();
        public static void HideCursor() => Raylib.HideCursor();
        public static bool IsCursorHidden() => Raylib.IsCursorHidden();
        public static void EnableCursor() => Raylib.EnableCursor();
        public static void DisableCursor() => Raylib.DisableCursor();
        public static bool IsCursorOnScreen() => Raylib.IsCursorOnScreen(); 
        
        // Drawing-related functions   
        public static void ClearBackground(Color color) => Raylib.ClearBackground((Raylib_cs.Color)color.GetSource());
        public static void BeginDrawing() => Raylib.BeginDrawing();
        public static void EndDrawing() => Raylib.EndDrawing();

        public static void BeginMode2D(Camera2D cam) => Raylib.BeginMode2D((Raylib_cs.Camera2D)cam.GetSource());
        public static void EndMode2D() => Raylib.EndMode2D();
        public static void BeginMode3D(Camera cam) => Raylib.BeginMode3D((Camera3D)cam.GetSource());
        public static void EndMode3D() => Raylib.EndMode3D();
        public static void BeginTextureMode(RenderTexture r) => Raylib.BeginTextureMode((RenderTexture2D)r.GetSource());
        public static void EndTextureMode() => Raylib.EndTextureMode();
        public static void BeginScissorMode(int x, int y, int w, int h) => Raylib.BeginScissorMode(x, y, w, h);
        public static void EndScissorMode() => Raylib.EndScissorMode();

        // Screen-space-related functions
        public static Ray GetMouseRay(Vector2 pos, Camera cam) => RLRAYTORAY(Raylib.GetMouseRay((snv2)pos.GetSource(), (Camera3D)cam.GetSource()));
        public static Matrix GetCameraMatrix(Camera cam) => RLMATRTOMATR(Raylib.GetCameraMatrix((Camera3D)cam.GetSource()));
        public static Matrix GetCameraMatrix2D(Camera2D cam) => RLMATRTOMATR(Raylib.GetCameraMatrix2D((Raylib_cs.Camera2D)cam.GetSource()));
        public static Vector2 GetWorldToScreen(Vector3 pos, Camera cam) => RLV2TOV2(Raylib.GetWorldToScreen((snv3)pos.GetSource(), (Raylib_cs.Camera3D)cam.GetSource()));
        public static Vector2 GetWorldToScreenEx(Vector3 pos, Camera cam, int w, int h) => RLV2TOV2(Raylib.GetWorldToScreenEx((snv3)pos.GetSource(), (Raylib_cs.Camera3D)cam.GetSource(), w, h));
        public static Vector2 GetWorldToScreen2D(Vector2 pos, Camera2D cam) => RLV2TOV2(Raylib.GetWorldToScreen2D((snv2)pos.GetSource(), (Raylib_cs.Camera2D)cam.GetSource()));
        public static Vector2 GetScreenToWorld2D(Vector2 pos, Camera2D cam) => RLV2TOV2(Raylib.GetScreenToWorld2D((snv2)pos.GetSource(), (Raylib_cs.Camera2D)cam.GetSource()));
        
        // Timing-related functions
        public static void SetTargetFPS(int fps) => Raylib.SetTargetFPS(fps);
        public static int GetFPS() => Raylib.GetFPS();
        public static float GetFrameTime() => Raylib.GetFrameTime();
        public static float GetTime() => (float)Raylib.GetTime();
        
        // Misc functions
        public static void SetConfigFlags(int flags) => Raylib.SetConfigFlags((ConfigFlag) flags);
        public static void SetTraceLogLevel(int logType) => Raylib.SetTraceLogLevel((TraceLogType)logType);
        public static void SetTraceLogExit(int logType) => Raylib.SetTraceLogExit((TraceLogType)logType);
        public static void TakeScreenshot(string filename) => Raylib.TakeScreenshot(filename);
        public static void GetRandomValue(int min, int max) => Raylib.GetRandomValue(min, max);
        
        // Files management functions
        /* mostly not needed in c# */

        // Persistant storage Management
        public static void SaveStorageValue(int pos, int value) => Raylib.StorageSaveValue(pos, value);
        public static int LoadStorageValue(int pos) => Raylib.StorageLoadValue(pos);
        public static void OpenURL(string url) => Raylib.OpenURL(url);
        
        // Input-related functions: keyboard
        public static bool IsKeyPressed(int key) => Raylib.IsKeyPressed((Raylib_cs.KeyboardKey)key);
        public static bool IsKeyDown(int key) => Raylib.IsKeyDown((Raylib_cs.KeyboardKey)key);
        public static bool IsKeyReleased(int key) => Raylib.IsKeyReleased((Raylib_cs.KeyboardKey)key);
        public static bool IsKeyUp(int key) => Raylib.IsKeyUp((Raylib_cs.KeyboardKey)key);
        public static void SetExitKey(int key) => Raylib.SetExitKey((Raylib_cs.KeyboardKey)key);
        public static int GetKeyPressed() => Raylib.GetKeyPressed();
        public static int GetCharPressed() => Raylib.GetCharPressed();

        // Input-related functions: gamepads
        public static bool IsGamepadAvailable(int gamepad) => Raylib.IsGamepadAvailable((GamepadNumber)gamepad);
        public static bool IsGamepadName(int gamepad, string name) => Raylib.IsGamepadName((GamepadNumber)gamepad, name);
        public static string GetGamepadName(int gamepad) => Raylib.GetGamepadName((GamepadNumber)gamepad);
        public static bool IsGamepadButtonPressed(int gamepad, int button) => Raylib.IsGamepadButtonPressed((GamepadNumber)gamepad, (GamepadButton)button);
        public static bool IsGamepadButtonDown(int gamepad, int button) => Raylib.IsGamepadButtonDown((GamepadNumber)gamepad, (GamepadButton)button);
        public static bool IsGamepadButtonReleased(int gamepad, int button) => Raylib.IsGamepadButtonReleased((GamepadNumber)gamepad, (GamepadButton)button);
        public static bool IsGamepadButtonUp(int gamepad, int button) => Raylib.IsGamepadButtonUp((GamepadNumber)gamepad, (GamepadButton)button);
        public static int GetGamepadButtonPressed() => Raylib.GetGamepadButtonPressed();
        public static int GetGamepadAxisCount(int gamepad) => Raylib.GetGamepadAxisCount((GamepadNumber)gamepad);
        public static float GetGamepadAxisMovement(int gamepad, int axis) => Raylib.GetGamepadAxisMovement((GamepadNumber)gamepad, (GamepadAxis)axis);
        
        // Input-related functions: mouse
        public static bool IsMouseButtonPressed(int button) => Raylib.IsMouseButtonPressed((MouseButton)button);
        public static bool IsMouseButtonDown(int button) => Raylib.IsMouseButtonDown((MouseButton)button);
        public static bool IsMouseButtonReleased(int button) => Raylib.IsMouseButtonReleased((MouseButton)button);
        public static bool IsMouseButtonUp(int button) => Raylib.IsMouseButtonUp((MouseButton)button);
        public static int GetMouseX() => Raylib.GetMouseX();
        public static int GetMouseY() => Raylib.GetMouseY();
        public static Vector2 GetMousePosition() => RLV2TOV2(Raylib.GetMousePosition());
        public static void SetMousePosition(int x, int y) => Raylib.SetMousePosition(x, y);
        public static void SetMouseOffset(int x, int y) => Raylib.SetMouseOffset(x, y);
        public static void SetMouseScale(float x, float y) => Raylib.SetMouseScale(x, y);
        public static float GetMouseWheelMove() => Raylib.GetMouseWheelMove();
        public static int GetMouseCursor() => (int)Raylib.GetMouseCursor();
        public static void SetMouseCursor(int cursor) => Raylib.SetMouseCursor((MouseCursor)cursor);

        // Input-related functions: touch
        public static int GetTouchX() => Raylib.GetTouchX();
        public static int GetTouchY() => Raylib.GetTouchY();
        public static Vector2 GetTouchPosition(int index) => RLV2TOV2(Raylib.GetTouchPosition(index));
        
        // Camera System Functions
        public static void SetCameraMode(Camera cam, int mode) => Raylib.SetCameraMode((Camera3D)cam.GetSource(), (CameraMode)mode);
        public static Camera UpdateCamera(Camera cam) { var camr = (Camera3D) cam.GetSource(); Raylib.UpdateCamera(ref camr); return RLCAMTOCAM(camr); }
        public static void SetCameraPanControl(int keypan) => Raylib.SetCameraPanControl((KeyboardKey)keypan);
        public static void SetCameraAltControl(int keyalt) => Raylib.SetCameraAltControl((KeyboardKey)keyalt);
        public static void SetCameraSmoothZoomControl(int keyzoom) => Raylib.SetCameraSmoothZoomControl((KeyboardKey)keyzoom);
        public static void SetCameraMoveControls(int f, int b, int r, int l, int u, int d) => Raylib.SetCameraMoveControls((KeyboardKey)f, (KeyboardKey)b, (KeyboardKey)r, (KeyboardKey)l, (KeyboardKey)u, (KeyboardKey)d);
        
        // Shapes Module
        public static void DrawPixel(int x, int y, Color c) => Raylib.DrawPixel(x, y, (Raylib_cs.Color)c.GetSource());
        public static void DrawPixelV(Vector2 pos, Color c) => Raylib.DrawPixelV((snv2)pos.GetSource(), (Raylib_cs.Color)c.GetSource());
        public static void DrawLine(int x, int y, int x1, int y1, Color c) => Raylib.DrawLine(x, y, x1, y1, (Raylib_cs.Color)c.GetSource());
        public static void DrawLineV(Vector2 pos, Vector3 pos1, Color c) => Raylib.DrawLineV((snv2)pos.GetSource(), (snv2)pos1.GetSource(), (Raylib_cs.Color)c.GetSource());
        public static void DrawLineEx(Vector2 pos, Vector3 pos1, float thick, Color c) => Raylib.DrawLineEx((snv2)pos.GetSource(), (snv2)pos1.GetSource(), thick, (Raylib_cs.Color)c.GetSource());
        public static void DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick, Color color) => Raylib.DrawLineBezier((snv2) startPos.GetSource(), (snv2) endPos.GetSource(), thick, (Raylib_cs.Color)color.GetSource());
        public static void DrawCircle(int centerX, int centerY, float radius, Color color) => Raylib.DrawCircle(centerX, centerY, radius, (Raylib_cs.Color) color.GetSource());
        public static void DrawCircleSector(Vector2 center, float radius, int startAngle, int endAngle, int segments, Color color) => Raylib.DrawCircleSector((snv2)center.GetSource(), radius, startAngle, endAngle, segments, (Raylib_cs.Color)color.GetSource());
        public static void DrawCircleSectorLines(Vector2 center, float radius, int startAngle, int endAngle, int segments, Color color) => Raylib.DrawCircleSectorLines((snv2)center.GetSource(), radius, startAngle, endAngle, segments, (Raylib_cs.Color)color.GetSource());
        public static void DrawCircleGradient(int centerX, int centerY, float radius, Color color1, Color color2) => Raylib.DrawCircleGradient(centerX, centerY, radius, (Raylib_cs.Color) color1.GetSource(), (Raylib_cs.Color) color2.GetSource());  
        public static void DrawCircleV(Vector2 center, float radius, Color color) => Raylib.DrawCircleV((snv2)center.GetSource(), radius, (Raylib_cs.Color)color.GetSource());                                        
        public static void DrawCircleLines(int centerX, int centerY, float radius, Color color) => Raylib.DrawCircleLines(centerX, centerY, radius, (Raylib_cs.Color)color.GetSource());                          
        public static void DrawEllipse(int centerX, int centerY, float radiusH, float radiusV, Color color) => Raylib.DrawEllipse(centerX, centerY, radiusH, radiusV, (Raylib_cs.Color)color.GetSource());              
        public static void DrawEllipseLines(int centerX, int centerY, float radiusH, float radiusV, Color color) => Raylib.DrawEllipseLines(centerX, centerY, radiusH, radiusV, (Raylib_cs.Color)color.GetSource());         
        public static void DrawRing(Vector2 center, float innerRadius, float outerRadius, int startAngle, int endAngle, int segments, Color color) => Raylib.DrawRing((snv2)center.GetSource(), innerRadius, outerRadius, startAngle, endAngle, segments, (Raylib_cs.Color)color.GetSource());
        public static void DrawRingLines(Vector2 center, float innerRadius, float outerRadius, int startAngle, int endAngle, int segments, Color color) => Raylib.DrawRingLines((snv2)center.GetSource(), innerRadius, outerRadius, startAngle, endAngle, segments, (Raylib_cs.Color)color.GetSource()); 
        public static void DrawRectangle(int posX, int posY, int width, int height, Color color) => Raylib.DrawRectangle(posX, posY, width, height, (Raylib_cs.Color)color.GetSource());
        public static void DrawRectangleV(Vector2 position, Vector2 size, Color color) => Raylib.DrawRectangleV((snv2)position.GetSource(), (snv2)size.GetSource(), (Raylib_cs.Color)color.GetSource());                                   
        public static void DrawRectangleRec(Rectangle rec, Color color) => Raylib.DrawRectangleRec((Raylib_cs.Rectangle)rec.GetSource(), (Raylib_cs.Color)color.GetSource());                                                  
        public static void DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation, Color color) => Raylib.DrawRectanglePro((Raylib_cs.Rectangle)rec.GetSource(), (snv2)origin.GetSource(), rotation, (Raylib_cs.Color)color.GetSource());
        public static void DrawRectangleGradientV(int posX, int posY, int width, int height, Color color1, Color color2) => Raylib.DrawRectangleGradientV(posX, posY, width, height, (Raylib_cs.Color)color1.GetSource(), (Raylib_cs.Color)color2.GetSource()); 
        public static void DrawRectangleGradientH(int posX, int posY, int width, int height, Color color1, Color color2) => Raylib.DrawRectangleGradientH(posX, posY, width, height, (Raylib_cs.Color)color1.GetSource(), (Raylib_cs.Color)color2.GetSource()); 
        public static void DrawRectangleGradientEx(Rectangle rec, Color col1, Color col2, Color col3, Color col4) => Raylib.DrawRectangleGradientEx((Raylib_cs.Rectangle)rec.GetSource(), (Raylib_cs.Color)col1.GetSource(), (Raylib_cs.Color)col2.GetSource(), (Raylib_cs.Color)col3.GetSource(), (Raylib_cs.Color)col4.GetSource());
        public static void DrawRectangleLines(int posX, int posY, int width, int height, Color color) => Raylib.DrawRectangleLines(posX, posY, width, height, (Raylib_cs.Color)color.GetSource());                    
        public static void DrawRectangleLinesEx(Rectangle rec, int lineThick, Color color) => Raylib.DrawRectangleLinesEx((Raylib_cs.Rectangle)rec.GetSource(), lineThick, (Raylib_cs.Color)color.GetSource());                               
        public static void DrawRectangleRounded(Rectangle rec, float roundness, int segments, Color color) => Raylib.DrawRectangleRounded((Raylib_cs.Rectangle)rec.GetSource(), roundness, segments, (Raylib_cs.Color)color.GetSource());               
        public static void DrawRectangleRoundedLines(Rectangle rec, float roundness, int segments, int lineThick, Color color) => Raylib.DrawRectangleRoundedLines((Raylib_cs.Rectangle)rec.GetSource(), roundness, segments, lineThick, (Raylib_cs.Color)color.GetSource());
        public static void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color) => Raylib.DrawTriangle((snv2)v1.GetSource(), (snv2)v2.GetSource(), (snv2)v3.GetSource(), (Raylib_cs.Color)color.GetSource());                                 
        public static void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color) => Raylib.DrawTriangleLines((snv2)v1.GetSource(), (snv2)v2.GetSource(), (snv2)v3.GetSource(), (Raylib_cs.Color)color.GetSource());
        public static void DrawPoly(Vector2 center, int sides, float radius, float rotation, Color color) => Raylib.DrawPoly((snv2)center.GetSource(), sides, radius, rotation, (Raylib_cs.Color)color.GetSource());                
        public static void DrawPolyLines(Vector2 center, int sides, float radius, float rotation, Color color) => Raylib.DrawPolyLines((snv2)center.GetSource(), sides, radius, rotation, (Raylib_cs.Color)color.GetSource()); 
        
        // Basic shapes collision detection functions
        public static bool CheckCollisionRecs(Rectangle rec1, Rectangle rec2) => Raylib.CheckCollisionRecs((Raylib_cs.Rectangle)rec1.GetSource(), (Raylib_cs.Rectangle)rec2.GetSource());                                            
        public static bool CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2, float radius2) => Raylib.CheckCollisionCircles((snv2)center1.GetSource(), radius1, (snv2)center2.GetSource(), radius2);         
        public static bool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec) => Raylib.CheckCollisionCircleRec((snv2)center.GetSource(), radius, (Raylib_cs.Rectangle)rec.GetSource());                          
        public static bool CheckCollisionPointRec(Vector2 point, Rectangle rec) => Raylib.CheckCollisionPointRec((snv2)point.GetSource(), (Raylib_cs.Rectangle)rec.GetSource());                                          
        public static bool CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius) => Raylib.CheckCollisionPointCircle((snv2)point.GetSource(), (snv2)center.GetSource(), radius);
        public static bool CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2, Vector2 p3) => Raylib.CheckCollisionPointTriangle((snv2)point.GetSource(), (snv2)p1.GetSource(), (snv2)p2.GetSource(),(snv2)p3.GetSource());                
        public static bool CheckCollisionLines(Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2) { snv2 rt = new snv2(); return Raylib.CheckCollisionLines((snv2)startPos1.GetSource(), (snv2)endPos1.GetSource(), (snv2)startPos2.GetSource(), (snv2)endPos2.GetSource(), ref rt); }
        public static Rectangle GetCollisionRec(Rectangle rec1, Rectangle rec2) => RLRECTTORECT(Raylib.GetCollisionRec((Raylib_cs.Rectangle)rec1.GetSource(), (Raylib_cs.Rectangle)rec2.GetSource())); 
        
        // Texture Module
        public static Image LoadImage(string filename) => RLIMGTOIMG(Raylib.LoadImage(filename));
        public static Image LoadImageRaw(string filename, int w, int h, int format, int headerSize) => RLIMGTOIMG(Raylib.LoadImageRaw(filename, w, h, (PixelFormat)format, headerSize));
        public static void UnloadImage(Image image) => Raylib.UnloadImage((Raylib_cs.Image) image.GetSource());
        public static void ExportImage(Image image, string filename) => Raylib.ExportImage((Raylib_cs.Image) image.GetSource(), filename);
        public static void ExportImageAsCode(Image image, string filename) => Raylib.ExportImageAsCode((Raylib_cs.Image) image.GetSource(), filename);
        
        // Image generation functions
        public static Image GenImageColor(int width, int height, Color color) => RLIMGTOIMG(Raylib.GenImageColor(width, height, (Raylib_cs.Color)color.GetSource()));                                           
        public static Image GenImageGradientV(int width, int height, Color top, Color bottom) => RLIMGTOIMG(Raylib.GenImageGradientV(width, height, (Raylib_cs.Color)top.GetSource(), (Raylib_cs.Color)bottom.GetSource()));                           
        public static Image GenImageGradientH(int width, int height, Color left, Color right) => RLIMGTOIMG(Raylib.GenImageGradientH(width, height, (Raylib_cs.Color)left.GetSource(), (Raylib_cs.Color)right.GetSource()));                           
        public static Image GenImageGradientRadial(int width, int height, float density, Color inner, Color outer) => RLIMGTOIMG(Raylib.GenImageGradientRadial(width, height, density, (Raylib_cs.Color)inner.GetSource(), (Raylib_cs.Color)outer.GetSource()));      
        public static Image GenImageChecked(int width, int height, int checksX, int checksY, Color col1, Color col2) => RLIMGTOIMG(Raylib.GenImageChecked(width, height, checksX, checksY, (Raylib_cs.Color)col1.GetSource(), (Raylib_cs.Color)col2.GetSource()));    
        public static Image GenImageWhiteNoise(int width, int height, float factor) => RLIMGTOIMG(Raylib.GenImageWhiteNoise(width, height, factor));                                   
        public static Image GenImagePerlinNoise(int width, int height, int offsetX, int offsetY, float scale) => RLIMGTOIMG(Raylib.GenImagePerlinNoise(width, height, offsetX, offsetY, scale));
        public static Image GenImageCellular(int width, int height, int tileSize) => RLIMGTOIMG(Raylib.GenImageCellular(width, height, tileSize));    
        
        // Image manipulation functions
        public static Image ImageCopy(Image image) => RLIMGTOIMG(Raylib.ImageCopy((Raylib_cs.Image)image.GetSource()));                                                                      
        public static Image ImageFromImage(Image image, Rectangle rec) => RLIMGTOIMG(Raylib.ImageFromImage((Raylib_cs.Image)image.GetSource(), (Raylib_cs.Rectangle)rec.GetSource()));                                                  
        public static Image ImageText(string text, int fontSize, Color color) => RLIMGTOIMG(Raylib.ImageText(text, fontSize, (Raylib_cs.Color)color.GetSource()));
        public static Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint) => RLIMGTOIMG(Raylib.ImageTextEx((Raylib_cs.Font)font.GetSource(), text, fontSize, spacing, (Raylib_cs.Color)tint.GetSource()));         
        public static Image ImageFormat(Image image, int newFormat) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageFormat(ref img, newFormat); return RLIMGTOIMG(img); }
        public static Image ImageToPOT(Image image, Color fill) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageToPOT(ref img, (Raylib_cs.Color)fill.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageCrop(Image image, Rectangle crop) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageCrop(ref img, (Raylib_cs.Rectangle)crop.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageAlphaCrop(Image image, float threshold) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageAlphaCrop(ref img, threshold); return RLIMGTOIMG(img); }                                               
        public static Image ImageAlphaClear(Image image, Color color, float threshold) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageAlphaClear(ref img,(Raylib_cs.Color)color.GetSource(), threshold); return RLIMGTOIMG(img); }                                 
        public static Image ImageAlphaMask(Image image, Image alphaMask) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageAlphaMask(ref img, (Raylib_cs.Image)alphaMask.GetSource()); return RLIMGTOIMG(img); }                                          
        public static Image ImageAlphaPremultiply(Image image) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageAlphaPremultiply(ref img); return RLIMGTOIMG(img); }                                                          
        public static Image ImageResize(Image image, int newWidth, int newHeight) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageResize(ref img, newWidth, newHeight); return RLIMGTOIMG(img); }                                     
        public static Image ImageResizeNN(Image image, int newWidth,int newHeight) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageResizeNN(ref img, newWidth, newHeight); return RLIMGTOIMG(img); }
        public static Image ImageResizeCanvas(Image image, int newWidth, int newHeight, int offsetX, int offsetY, Color fill) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageResizeCanvas(ref img, newWidth, newHeight, offsetX, offsetY, (Raylib_cs.Color)fill.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageMipmaps(Image image) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageMipmaps(ref img); return RLIMGTOIMG(img); }                                                                   
        public static Image ImageDither(Image image, int rBpp, int gBpp, int bBpp, int aBpp) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageDither(ref img, rBpp, gBpp, bBpp, aBpp); return RLIMGTOIMG(img); }                         
        public static Image ImageFlipVertical(Image image) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageFlipVertical(ref img); return RLIMGTOIMG(img); }                                                           
        public static Image ImageFlipHorizontal(Image image) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageFlipHorizontal(ref img); return RLIMGTOIMG(img); }                                                          
        public static Image ImageRotateCW(Image image) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageRotateCW(ref img); return RLIMGTOIMG(img); }                                                      
        public static Image ImageRotateCCW(Image image) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageRotateCCW(ref img); return RLIMGTOIMG(img); }                                                       
        public static Image ImageColorTint(Image image, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageColorTint(ref img, (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }                                                 
        public static Image ImageColorInvert(Image image) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageColorInvert(ref img); return RLIMGTOIMG(img); }
        public static Image ImageColorGrayscale(Image image) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageColorGrayscale(ref img); return RLIMGTOIMG(img); }                                                        
        public static Image ImageColorContrast(Image image, float contrast) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageColorContrast(ref img, contrast); return RLIMGTOIMG(img); }                                           
        public static Image ImageColorBrightness(Image image, int brightness) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageColorBrightness(ref img, brightness); return RLIMGTOIMG(img); }                                        
        public static Image ImageColorReplace(Image image, Color color, Color replace) { Raylib_cs.Image img = (Raylib_cs.Image)image.GetSource(); Raylib.ImageColorReplace(ref img, (Raylib_cs.Color)color.GetSource(), (Raylib_cs.Color)replace.GetSource()); return RLIMGTOIMG(img); }
        public static Rectangle GetImageAlphaBorder(Image image, float threshold) => RLRECTTORECT(Raylib.GetImageAlphaBorder((Raylib_cs.Image)image.GetSource(), threshold));
        
        // Image drawing functions
        public static Image ImageClearBackground(Image dst, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageClearBackground(ref img, (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }                                              
        public static Image ImageDrawPixel(Image dst, int posX, int posY, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawPixel(ref img, posX, posY, (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }                             
        public static Image ImageDrawPixelV(Image dst, Vector2 position, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawPixelV(ref img, (snv2)position.GetSource(), (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }                               
        public static Image ImageDrawLine(Image dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawLine(ref img, startPosX, startPosY, endPosX, endPosY, (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageDrawLineV(Image dst, Vector2 start, Vector2 end, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawLineV(ref img, (snv2)start.GetSource(), (snv2)start.GetSource(), (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }                      
        public static Image ImageDrawCircle(Image dst, int centerX, int centerY, int radius, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawCircle(ref img, centerX, centerY, radius, (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageDrawCircleV(Image dst, Vector2 center, int radius, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawCircleV(ref img, (snv2)center.GetSource(), radius, (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageDrawRectangle(Image dst, int posX, int posY, int width, int height, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawRectangle(ref img, posX, posY, width, height, (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageDrawRectangleV(Image dst, Vector2 position, Vector2 size, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawRectangleV(ref img, (snv2)position.GetSource(), (snv2)size.GetSource(), (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageDrawRectangleRec(Image dst, Rectangle rec, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawRectangleRec(ref img, (Raylib_cs.Rectangle)rec.GetSource(), (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }                   
        public static Image ImageDrawRectangleLines(Image dst, Rectangle rec, int thick, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawRectangleLines(ref img, (Raylib_cs.Rectangle)rec.GetSource(), thick, (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }                
        public static Image ImageDraw(Image dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDraw(ref img, (Raylib_cs.Image)src.GetSource(), (Raylib_cs.Rectangle)srcRec.GetSource(), (Raylib_cs.Rectangle)dstRec.GetSource(), (Raylib_cs.Color)tint.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageDrawText(Image dst, string text, int posX, int posY, int fontSize, Color color) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawText(ref img, text, posX, posY, fontSize, (Raylib_cs.Color)color.GetSource()); return RLIMGTOIMG(img); }
        public static Image ImageDrawTextEx(Image dst, Font font, string text, Vector2 position, float fontSize, float spacing, Color tint) { Raylib_cs.Image img = (Raylib_cs.Image)dst.GetSource(); Raylib.ImageDrawTextEx(ref img, (Raylib_cs.Font)font.GetSource(), text, (snv2)position.GetSource(), fontSize, spacing, (Raylib_cs.Color)tint.GetSource()); return RLIMGTOIMG(img); }

        // Texture loading functions
        public static Texture LoadTexture(string fileName) => RLTEXTOTEX(Raylib.LoadTexture(fileName));
        public static Texture LoadTextureFromImage(Image image) => RLTEXTOTEX(Raylib.LoadTextureFromImage((Raylib_cs.Image)image.GetSource()));
        public static RenderTexture LoadRenderTexture(int width, int height) => RLRTEXTORTEX(Raylib.LoadRenderTexture(width, height));
        public static void UnloadTexture(Texture texture) => Raylib.UnloadTexture((Texture2D)texture.GetSource());                                                   
        public static void UnloadRenderTexture(RenderTexture target) => Raylib.UnloadRenderTexture((RenderTexture2D)target.GetSource());
        public static Image GetTextureData(Texture texture) => RLIMGTOIMG(Raylib.GetTextureData((Texture2D)texture.GetSource()));
        public static Image GetScreenData() => RLIMGTOIMG(Raylib.GetScreenData());
        
        // Texture configuration functions
        public static Texture GenTextureMipmaps(Texture texture) { Texture2D tex = (Texture2D)texture.GetSource(); Raylib.GenTextureMipmaps(ref tex); return RLTEXTOTEX(tex); }
        public static void SetTextureFilter(Texture texture, int filterMode) => Raylib.SetTextureFilter((Texture2D)texture.GetSource(), (TextureFilterMode)filterMode);
        public static void SetTextureWrap(Texture texture, int wrapMode) => Raylib.SetTextureWrap((Texture2D)texture.GetSource(), (TextureWrapMode)wrapMode);
        
        // Texture drawing functions
        public static void DrawTexture(Texture texture, int posX, int posY, Color tint) => Raylib.DrawTexture((Texture2D)texture.GetSource(), posX, posY, (Raylib_cs.Color)tint.GetSource());                     
        public static void DrawTextureV(Texture texture, Vector2 position, Color tint) => Raylib.DrawTextureV((Texture2D)texture.GetSource(),(snv2)position.GetSource(), (Raylib_cs.Color)tint.GetSource());
        public static void DrawTextureEx(Texture texture, Vector2 position, float rotation, float scale, Color tint) => Raylib.DrawTextureEx((Texture2D)texture.GetSource(), (snv2)position.GetSource(), rotation, scale, (Raylib_cs.Color)tint.GetSource());  
        public static void DrawTextureRec(Texture texture, Rectangle source, Vector2 position, Color tint) => Raylib.DrawTextureRec((Texture2D)texture.GetSource(), (Raylib_cs.Rectangle)source.GetSource(),(snv2)position.GetSource(), (Raylib_cs.Color)tint.GetSource());
        public static void DrawTextureQuad(Texture texture, Vector2 tiling, Vector2 offset, Rectangle quad, Color tint) => Raylib.DrawTextureQuad((Texture2D)texture.GetSource(), (snv2)tiling.GetSource(), (snv2)offset.GetSource(), (Raylib_cs.Rectangle)quad.GetSource(), (Raylib_cs.Color)tint.GetSource());
        public static void DrawTextureTiled(Texture texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, float scale, Color tint) => Raylib.DrawTextureTiled((Texture2D)texture.GetSource(), (Raylib_cs.Rectangle)source.GetSource(), (Raylib_cs.Rectangle)dest.GetSource(), (snv2)origin.GetSource(), rotation, scale, (Raylib_cs.Color)tint.GetSource());
        public static void DrawTexturePro(Texture texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, Color tint) => Raylib.DrawTexturePro((Texture2D)texture.GetSource(), (Raylib_cs.Rectangle)source.GetSource(), (Raylib_cs.Rectangle)dest.GetSource(), (snv2)origin.GetSource(), rotation, (Raylib_cs.Color)tint.GetSource());
        public static void DrawTextureNPatch(Texture texture, NPatchInfo nPatchInfo, Rectangle dest, Vector2 origin, float rotation, Color tint) => Raylib.DrawTextureNPatch((Texture2D)texture.GetSource(), (Raylib_cs.NPatchInfo)nPatchInfo.GetSource(), (Raylib_cs.Rectangle)dest.GetSource(), (snv2)origin.GetSource(), rotation, (Raylib_cs.Color)tint.GetSource());
        
        // Color/pixel related functions
        public static Color Fade(Color color, float alpha) => RLCOLTOCOL(Raylib.Fade((Raylib_cs.Color)color.GetSource(), alpha));                        
        public static int ColorToInt(Color color) => Raylib.ColorToInt((Raylib_cs.Color)color.GetSource());
        public static Vector4 ColorNormalize(Color color) => RLV4TOV4(Raylib.ColorNormalize((Raylib_cs.Color)color.GetSource()));
        public static Color ColorFromNormalized(Vector4 normalized) => RLCOLTOCOL(Raylib.ColorFromNormalized((System.Numerics.Vector4)normalized.GetSource()));
        public static Vector3 ColorToHSV(Color color) => RLV3TOV3(Raylib.ColorToHSV((Raylib_cs.Color)color.GetSource())); 
        public static Color ColorFromHSV(float hue, float saturation, float value) => RLCOLTOCOL(Raylib.ColorFromHSV(hue, saturation, value));
        public static Color ColorAlpha(Color color, float alpha) => RLCOLTOCOL(Raylib.ColorAlpha((Raylib_cs.Color)color.GetSource(), alpha));
        public static Color ColorAlphaBlend(Color dst, Color src, Color tint) => RLCOLTOCOL(Raylib.ColorAlphaBlend((Raylib_cs.Color)dst.GetSource(), (Raylib_cs.Color)src.GetSource(), (Raylib_cs.Color)tint.GetSource()));
        public static Color GetColor(int hexValue) => RLCOLTOCOL(Raylib.GetColor(hexValue));
        public static int GetPixelDataSize(int width, int height, int format) => Raylib.GetPixelDataSize(width, height, (PixelFormat)format); 
        
        // Text Module
        public static Font GetFontDefault() => RLFNTTOFNT(Raylib.GetFontDefault());                                                           
        public static Font LoadFont(string fileName) => RLFNTTOFNT(Raylib.LoadFont(fileName));
        public static Font LoadFontFromImage(Image image, Color key, int firstChar) => RLFNTTOFNT(Raylib.LoadFontFromImage((Raylib_cs.Image)image.GetSource(), (Raylib_cs.Color)key.GetSource(), firstChar));
        public static void UnloadFont(Font font) => Raylib.UnloadFont((Raylib_cs.Font)font.GetSource());
        
        // Text drawing functions
        public static void DrawFPS(int posX, int posY) => Raylib.DrawFPS(posX, posY);                                              
        public static void DrawText(string text, int posX, int posY, int fontSize, Color color) => Raylib.DrawText(text, posX, posY, fontSize, (Raylib_cs.Color)color.GetSource());
        public static void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint) => Raylib.DrawTextEx((Raylib_cs.Font)font.GetSource(), text, (snv2)position.GetSource(), fontSize, spacing, (Raylib_cs.Color)tint.GetSource());
        public static void DrawTextRec(Font font, string text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint) => Raylib.DrawTextRec((Raylib_cs.Font)font.GetSource(), text, (Raylib_cs.Rectangle)rec.GetSource(), fontSize, spacing, wordWrap, (Raylib_cs.Color)tint.GetSource());
        public static void DrawTextRecEx(Font font, string text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint, int selectStart, int selectLength, Color selectTint, Color selectBackTint) => Raylib.DrawTextRecEx((Raylib_cs.Font)font.GetSource(), text, (Raylib_cs.Rectangle)rec.GetSource(), fontSize, spacing, wordWrap, (Raylib_cs.Color)tint.GetSource(), selectStart, selectLength, (Raylib_cs.Color)selectTint.GetSource(), (Raylib_cs.Color)selectBackTint.GetSource());
        public static void DrawTextCodepoint(Font font, int codepoint, Vector2 position, float fontSize, Color tint) => Raylib.DrawTextCodepoint((Raylib_cs.Font)font.GetSource(), codepoint, (snv2)position.GetSource(), fontSize, (Raylib_cs.Color)tint.GetSource()); 
        
        // Text misc. functions
        public static int MeasureText(string text, int fontSize) => Raylib.MeasureText(text, fontSize);                                  
        public static Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing) => RLV2TOV2(Raylib.MeasureTextEx((Raylib_cs.Font)font.GetSource(), text, fontSize, spacing));
        public static int GetGlyphIndex(Font font, int codepoint) => Raylib.GetGlyphIndex((Raylib_cs.Font)font.GetSource(), codepoint); 
        
        // Text strings management functions (no utf8 strings, only byte chars)
        public static string TextReplace(string text, string replace, string by) => text.Replace(replace, by);           
        public static string TextInsert(string text, string insert, int position) => text.Insert(position, insert);
        public static string[] TextSplit(string text, string delimiter) => text.Split(delimiter);         
        public static string TextAppend(string text, string append) => text += append;               
        public static int TextFindIndex(string text, string find) => text.IndexOf(find[0]);                        
        public static string TextToUpper(string text) => text.ToUpper();                                    
        public static string TextToLower(string text) => text.ToLower();                                    
        public static string TextToPascal(string text) => Raylib.TextToPascal(text);                                   
        public static int TextToInteger(string text) => Raylib.TextToInteger(text);                                          
        public static string TextToUtf8(string text, int length) => Raylib.TextToUtf8(text, length); 
        
        // UTF8 text strings management functions
        public static int[] GetCodepoints(string text) { int count = 0; return Raylib.GetCodepoints(text, ref count); }           
        public static int GetCodepointsCount(string text) => Raylib.GetCodepointsCount(text);

        // Model Module
        public static void DrawLine3D(Vector3 startPos, Vector3 endPos, Color color) => Raylib.DrawLine3D((snv3)startPos.GetSource(), (snv3)endPos.GetSource(), (Raylib_cs.Color)color.GetSource());
        public static void DrawPoint3D(Vector3 position, Color color) => Raylib.DrawPoint3D((snv3)position.GetSource(), (Raylib_cs.Color)color.GetSource());                
        public static void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle, Color color) => Raylib.DrawCircle3D((snv3)center.GetSource(), radius, (snv3)rotationAxis.GetSource(), rotationAngle, (Raylib_cs.Color)color.GetSource()); 
        public static void DrawTriangle3D(Vector3 v1, Vector3 v2, Vector3 v3, Color color) => Raylib.DrawTriangle3D((snv3)v1.GetSource(), (snv3)v2.GetSource(), (snv3)v3.GetSource(), (Raylib_cs.Color)color.GetSource());
        public static void DrawCube(Vector3 position, float width, float height, float length, Color color) => Raylib.DrawCube((snv3)position.GetSource(), width, height, length, (Raylib_cs.Color)color.GetSource());     
        public static void DrawCubeV(Vector3 position, Vector3 size, Color color) => Raylib.DrawCubeV((snv3)position.GetSource(), (snv3)size.GetSource(), (Raylib_cs.Color)color.GetSource());                               
        public static void DrawCubeWires(Vector3 position, float width, float height, float length, Color color) => Raylib.DrawCubeWires((snv3)position.GetSource(), width, height, length, (Raylib_cs.Color)color.GetSource());
        public static void DrawCubeWiresV(Vector3 position, Vector3 size, Color color) => Raylib.DrawCubeWiresV((snv3)position.GetSource(), (snv3)size.GetSource(), (Raylib_cs.Color)color.GetSource());                          
        public static void DrawCubeTexture(Texture texture, Vector3 position, float width, float height, float length, Color color) => Raylib.DrawCubeTexture((Texture2D)texture.GetSource(), (snv3)position.GetSource(), width, height, length, (Raylib_cs.Color)color.GetSource());
        public static void DrawSphere(Vector3 centerPos, float radius, Color color) => Raylib.DrawSphere((snv3)centerPos.GetSource(), radius, (Raylib_cs.Color)color.GetSource());                            
        public static void DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices, Color color) => Raylib.DrawSphereEx((snv3)centerPos.GetSource(), radius, rings, slices, (Raylib_cs.Color)color.GetSource());  
        public static void DrawSphereWires(Vector3 centerPos, float radius, int rings, int slices, Color color) => Raylib.DrawSphereWires((snv3)centerPos.GetSource(), radius, rings, slices, (Raylib_cs.Color)color.GetSource());
        public static void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color) => Raylib.DrawCylinder((snv3)position.GetSource(), radiusTop, radiusBottom, height, slices, (Raylib_cs.Color)color.GetSource());
        public static void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color) => Raylib.DrawCylinderWires((snv3)position.GetSource(), radiusTop, radiusBottom, height, slices, (Raylib_cs.Color)color.GetSource());
        public static void DrawPlane(Vector3 centerPos, Vector2 size, Color color) => Raylib.DrawPlane((snv3)centerPos.GetSource(), (snv2)size.GetSource(), (Raylib_cs.Color)color.GetSource()); 
        public static void DrawRay(Ray ray, Color color) => Raylib.DrawRay((Raylib_cs.Ray)ray.GetSource(), (Raylib_cs.Color)color.GetSource());                           
        public static void DrawGrid(int slices, float spacing) => Raylib.DrawGrid(slices, spacing);                     
        public static void DrawGizmo(Vector3 position) => Raylib.DrawGizmo((snv3)position.GetSource());
        
        // Model loading/unloading functions
        public static Model LoadModel(string fileName) => RLMODTOMOD(Raylib.LoadModel(fileName));
        public static Model LoadModelFromMesh(Mesh mesh) => RLMODTOMOD(Raylib.LoadModelFromMesh((Raylib_cs.Mesh)mesh.GetSource()));   
        public static void UnloadModel(Model model) => Raylib.UnloadModel((Raylib_cs.Model)model.GetSource());        
        public static void UnloadModelKeepMeshes(Model model) => Raylib.UnloadModelKeepMeshes((Raylib_cs.Model)model.GetSource()); 
        
        // Mesh loading/unloading functions                                                                
        public static bool ExportMesh(Mesh mesh, string fileName) => Raylib.ExportMesh((Raylib_cs.Mesh)mesh.GetSource(), fileName); 
        
        // Material loading/unloading functions                                     
        public static Material LoadMaterialDefault() => RLMATTOMAT(Raylib.LoadMaterialDefault());                                         
        public static void UnloadMaterial(Material material) => Raylib.UnloadMaterial((Raylib_cs.Material)material.GetSource());                                     
        public static Material SetMaterialTexture(Material material, int mapType, Texture texture) { Raylib_cs.Material mat = (Raylib_cs.Material)material.GetSource(); Raylib.SetMaterialTexture(ref mat, mapType, (Texture2D)texture.GetSource()); return RLMATTOMAT(mat); }
        public static Model SetModelMeshMaterial(Model model, int meshId, int materialId) { Raylib_cs.Model mod = (Raylib_cs.Model)model.GetSource(); Raylib.SetModelMeshMaterial(ref mod, meshId, materialId); return RLMODTOMOD(mod); }   
        
        // Mesh generation functions                                                                       
        public static Mesh GenMeshPoly(int sides, float radius) => RLMESHTOMESH(Raylib.GenMeshPoly(sides, radius));                         
        public static Mesh GenMeshPlane(float width, float length, int resX, int resZ) => RLMESHTOMESH(Raylib.GenMeshPlane(width, length, resX, resZ));  
        public static Mesh GenMeshCube(float width, float height, float length) => RLMESHTOMESH(Raylib.GenMeshCube(width, height, length));         
        public static Mesh GenMeshSphere(float radius, int rings, int slices) => RLMESHTOMESH(Raylib.GenMeshSphere(radius, rings, slices));
        public static Mesh GenMeshHemiSphere(float radius, int rings, int slices) => RLMESHTOMESH(Raylib.GenMeshHemiSphere(radius, rings, slices));
        public static Mesh GenMeshCylinder(float radius, float height, int slices) => RLMESHTOMESH(Raylib.GenMeshCylinder(radius, height, slices));
        public static Mesh GenMeshTorus(float radius, float size, int radSeg, int sides) => RLMESHTOMESH(Raylib.GenMeshTorus(radius, size, radSeg, sides));
        public static Mesh GenMeshKnot(float radius, float size, int radSeg, int sides) => RLMESHTOMESH(Raylib.GenMeshKnot(radius, size, radSeg, sides)); 
        public static Mesh GenMeshHeightmap(Image heightmap, Vector3 size) => RLMESHTOMESH(Raylib.GenMeshHeightmap((Raylib_cs.Image)heightmap.GetSource(), (snv3)size.GetSource()));              
        public static Mesh GenMeshCubicmap(Image cubicmap, Vector3 cubeSize) => RLMESHTOMESH(Raylib.GenMeshCubicmap((Raylib_cs.Image)cubicmap.GetSource(), (snv3)cubeSize.GetSource()));    
        
        // Mesh manipulation functions                                                                         
        public static BoundingBox MeshBoundingBox(Mesh mesh) => RLBDBTOBDB(Raylib.MeshBoundingBox((Raylib_cs.Mesh)mesh.GetSource()));
        public static Mesh MeshTangents(Mesh mesh) { Raylib_cs.Mesh m = (Raylib_cs.Mesh)mesh.GetSource(); Raylib.MeshTangents(ref m); return RLMESHTOMESH(m);  }       
        public static Mesh MeshBinormals(Mesh mesh) { Raylib_cs.Mesh m = (Raylib_cs.Mesh)mesh.GetSource(); Raylib.MeshBinormals(ref m); return RLMESHTOMESH(m);  }     
        public static Mesh MeshNormalsSmooth(Mesh mesh) { Raylib_cs.Mesh m = (Raylib_cs.Mesh)mesh.GetSource(); Raylib.MeshNormalsSmooth(ref m); return RLMESHTOMESH(m);  }
        
        // Model drawing functions
        public static void DrawModel(Model model, Vector3 position, float scale, Color tint) => Raylib.DrawModel((Raylib_cs.Model)model.GetSource(), (snv3)position.GetSource(), scale, (Raylib_cs.Color)tint.GetSource());
        public static void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint) => Raylib.DrawModelEx((Raylib_cs.Model)model.GetSource(), (snv3)position.GetSource(), (snv3)rotationAxis.GetSource(), rotationAngle, (snv3)scale.GetSource(), (Raylib_cs.Color)tint.GetSource());
        public static void DrawModelWires(Model model, Vector3 position, float scale, Color tint) => Raylib.DrawModelWires((Raylib_cs.Model)model.GetSource(), (snv3)position.GetSource(), scale, (Raylib_cs.Color)tint.GetSource()); 
        public static void DrawModelWiresEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint) => Raylib.DrawModelWiresEx((Raylib_cs.Model)model.GetSource(), (snv3)position.GetSource(), (snv3)rotationAxis.GetSource(), rotationAngle, (snv3)scale.GetSource(), (Raylib_cs.Color)tint.GetSource());
        public static void DrawBoundingBox(BoundingBox box, Color color) => Raylib.DrawBoundingBox((Raylib_cs.BoundingBox)box.GetSource(), (Raylib_cs.Color)color.GetSource());                                          
        public static void DrawBillboard(Camera camera, Texture texture, Vector3 center, float size, Color tint) => Raylib.DrawBillboard((Camera3D)camera.GetSource(), (Texture2D)texture.GetSource(), (snv3)center.GetSource(), size, (Raylib_cs.Color)tint.GetSource());
        public static void DrawBillboardRec(Camera camera, Texture texture, Rectangle source, Vector3 center, float size, Color tint) => Raylib.DrawBillboardRec((Camera3D)camera.GetSource(), (Texture2D)texture.GetSource(), (Raylib_cs.Rectangle)source.GetSource(), (snv3)center.GetSource(), size, (Raylib_cs.Color)tint.GetSource());
        
        // Collision detection functions
        public static bool CheckCollisionSpheres(Vector3 center1, float radius1, Vector3 center2, float radius2) => Raylib.CheckCollisionSpheres((snv3)center1.GetSource(), radius1, (snv3)center2.GetSource(), radius2);    
        public static bool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2) => Raylib.CheckCollisionBoxes((Raylib_cs.BoundingBox)box1.GetSource(), (Raylib_cs.BoundingBox)box2.GetSource());                                  
        public static bool CheckCollisionBoxSphere(BoundingBox box, Vector3 center, float radius) => Raylib.CheckCollisionBoxSphere((Raylib_cs.BoundingBox)box.GetSource(), (snv3)center.GetSource(), radius);                   
        public static bool CheckCollisionRaySphere(Ray ray, Vector3 center, float radius) => Raylib.CheckCollisionRaySphere((Raylib_cs.Ray)ray.GetSource(), (snv3)center.GetSource(), radius);
        public static bool CheckCollisionRayBox(Ray ray, BoundingBox box) => Raylib.CheckCollisionRayBox((Raylib_cs.Ray)ray.GetSource(), (Raylib_cs.BoundingBox)box.GetSource());
        public static RayHitInfo GetCollisionRayModel(Ray ray, Model model) => RLRINFOTORINFO(Raylib.GetCollisionRayModel((Raylib_cs.Ray)ray.GetSource(), (Raylib_cs.Model)model.GetSource()));                                         
        public static RayHitInfo GetCollisionRayTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3) => RLRINFOTORINFO(Raylib.GetCollisionRayTriangle((Raylib_cs.Ray)ray.GetSource(), (snv3)p1.GetSource(), (snv3)p2.GetSource(), (snv3)p3.GetSource()));               
        public static RayHitInfo GetCollisionRayGround(Ray ray, float groundHeight) => RLRINFOTORINFO(Raylib.GetCollisionRayGround((Raylib_cs.Ray)ray.GetSource(), groundHeight));
        
        // Module Shaders (rlgl)
        public static Shader LoadShader(string vsFileName, string fsFileName) => RLSHTOSH(Raylib.LoadShader(vsFileName, fsFileName));
        public static Shader LoadShaderCode(string vsCode, string fsCode) => RLSHTOSH(Raylib.LoadShaderCode(vsCode, fsCode));    
        public static void UnloadShader(Shader shader) => Raylib.UnloadShader((Raylib_cs.Shader)shader.GetSource());
        
        public static Shader GetShaderDefault() => RLSHTOSH(Raylib.GetShaderDefault());                             
        public static Texture GetTextureDefault() => RLTEXTOTEX(Raylib.GetTextureDefault());                         
        public static Texture GetShapesTexture() => RLTEXTOTEX(Raylib.GetShapesTexture());                          
        public static Rectangle GetShapesTextureRec() => RLRECTTORECT(Raylib.GetShapesTextureRec());                       
        public static void SetShapesTexture(Texture texture, Rectangle source) => Raylib.SetShapesTexture((Texture2D)texture.GetSource(), (Raylib_cs.Rectangle)source.GetSource());
        
        // Shader configuration functions
        public static int GetShaderLocation(Shader shader, string uniformName) => Raylib.GetShaderLocation((Raylib_cs.Shader)shader.GetSource(), uniformName);                                      
        public static int GetShaderLocationAttrib(Shader shader, string attribName) => Raylib.GetShaderLocationAttrib((Raylib_cs.Shader)shader.GetSource(), attribName);                                 
        public static void SetShaderValue(Shader shader, int uniformLoc, float value) { float v = value; Raylib.SetShaderValue((Raylib_cs.Shader)shader.GetSource(), uniformLoc, ref v, ShaderUniformDataType.UNIFORM_FLOAT); }
        public static void SetShaderValueMatrix(Shader shader, int uniformLoc, Matrix mat) => Raylib.SetShaderValueMatrix((Raylib_cs.Shader)shader.GetSource(), uniformLoc, (System.Numerics.Matrix4x4)mat.GetSource());                               
        public static void SetShaderValueTexture(Shader shader, int uniformLoc, Texture texture) => Raylib.SetShaderValueTexture((Raylib_cs.Shader)shader.GetSource(), uniformLoc, (Texture2D)texture.GetSource());                       
        public static void SetMatrixProjection(Matrix proj) => Raylib.SetMatrixProjection((Matrix4x4)proj.GetSource());                                                              
        public static void SetMatrixModelview(Matrix view) => Raylib.SetMatrixModelview((Matrix4x4)view.GetSource());                                                               
        public static Matrix GetMatrixModelview() => RLMATRTOMATR(Raylib.GetMatrixModelview());                                                                    
        public static Matrix GetMatrixProjection() => RLMATRTOMATR(Raylib.GetMatrixProjection()); 
        
        // Shading begin/end functions
        public static void BeginShaderMode(Shader shader) => Raylib.BeginShaderMode((Raylib_cs.Shader)shader.GetSource());
        public static void EndShaderMode() => Raylib.EndShaderMode();           
        public static void BeginBlendMode(int mode) => Raylib.BeginBlendMode((BlendMode)mode);      
        public static void EndBlendMode() => Raylib.EndBlendMode();   
        
        // VR control functions
        public static void InitVrSimulator() => Raylib.InitVrSimulator();                                   
        public static void CloseVrSimulator() => Raylib.CloseVrSimulator();                                  
        public static Camera UpdateVrTracking(Camera camera) { Camera3D cam = (Camera3D)camera.GetSource(); Raylib.UpdateVrTracking(ref cam); return RLCAMTOCAM(cam); }                        
        public static void SetVrConfiguration(VrDeviceInfo info, Shader distortion) => Raylib.SetVrConfiguration((Raylib_cs.VrDeviceInfo)info.GetSource(), (Raylib_cs.Shader)distortion.GetSource());
        public static bool IsVrSimulatorReady() => Raylib.IsVrSimulatorReady();                                
        public static void ToggleVrMode() => Raylib.ToggleVrMode();                                      
        public static void BeginVrDrawing() => Raylib.BeginVrDrawing();                                    
        public static void EndVrDrawing() => Raylib.EndVrDrawing();
        
        // Module Audio
        public static void InitAudioDevice() => Raylib.InitAudioDevice();   
        public static void CloseAudioDevice() => Raylib.CloseAudioDevice();  
        public static bool IsAudioDeviceReady() => Raylib.IsAudioDeviceReady();
        public static void SetMasterVolume(float volume) => Raylib.SetMasterVolume(volume);
        
        // Wave/Sound loading/unloading functions
        public static Wave LoadWave(string fileName) => RLWAVTOWAV(Raylib.LoadWave(fileName));
        public static Sound LoadSound(string fileName) => RLSNDTOSND(Raylib.LoadSound(fileName));                                        
        public static Sound LoadSoundFromWave(Wave wave) => RLSNDTOSND(Raylib.LoadSoundFromWave((Raylib_cs.Wave)wave.GetSource()));
        public static void UnloadWave(Wave wave) => Raylib.UnloadWave((Raylib_cs.Wave)wave.GetSource());                                                   
        public static void UnloadSound(Sound sound) => Raylib.UnloadSound((Raylib_cs.Sound)sound.GetSource());                                                
        public static void ExportWave(Wave wave, string fileName) => Raylib.ExportWave((Raylib_cs.Wave)wave.GetSource(), fileName);                             
        public static void ExportWaveAsCode(Wave wave, string fileName) => Raylib.ExportWaveAsCode((Raylib_cs.Wave)wave.GetSource(), fileName); 
        
        // Wave/Sound management functions
        public static void PlaySound(Sound sound) => Raylib.PlaySound((Raylib_cs.Sound)sound.GetSource());                                              
        public static void StopSound(Sound sound) => Raylib.StopSound((Raylib_cs.Sound)sound.GetSource());                                              
        public static void PauseSound(Sound sound) => Raylib.PauseSound((Raylib_cs.Sound)sound.GetSource());                                             
        public static void ResumeSound(Sound sound) => Raylib.ResumeSound((Raylib_cs.Sound)sound.GetSource());                                            
        public static void PlaySoundMulti(Sound sound) => Raylib.PlaySoundMulti((Raylib_cs.Sound)sound.GetSource());                                         
        public static void StopSoundMulti() => Raylib.StopSoundMulti();     
        public static int GetSoundsPlaying() => Raylib.GetSoundsPlaying();                                               
        public static bool IsSoundPlaying(Sound sound) => Raylib.IsSoundPlaying((Raylib_cs.Sound)sound.GetSource());                                         
        public static void SetSoundVolume(Sound sound, float volume) => Raylib.SetSoundVolume((Raylib_cs.Sound)sound.GetSource(), volume);                           
        public static void SetSoundPitch(Sound sound, float pitch) => Raylib.SetSoundPitch((Raylib_cs.Sound)sound.GetSource(), pitch);                             
        public static Wave WaveFormat(Wave wave, int sampleRate, int sampleSize, int channels) { Raylib_cs.Wave wav = (Raylib_cs.Wave) wave.GetSource(); Raylib.WaveFormat(ref wav, sampleRate, sampleSize, channels); return RLWAVTOWAV(wav);}
        public static Wave WaveCopy(Wave wave) => RLWAVTOWAV(Raylib.WaveCopy((Raylib_cs.Wave)wave.GetSource()));                                                 
        public static Wave WaveCrop(Wave wave, int initSample, int finalSample) { Raylib_cs.Wave wav = (Raylib_cs.Wave)wave.GetSource(); Raylib.WaveCrop(ref wav, initSample, finalSample); return RLWAVTOWAV(wav); }

        // Music management functions
        public static Music LoadMusicStream(string fileName) => RLMUSTOMUS(Raylib.LoadMusicStream(fileName));   
        public static void UnloadMusicStream(Music music) => Raylib.UnloadMusicStream((Raylib_cs.Music)music.GetSource());           
        public static void PlayMusicStream(Music music) => Raylib.PlayMusicStream((Raylib_cs.Music)music.GetSource());             
        public static void UpdateMusicStream(Music music) => Raylib.UpdateMusicStream((Raylib_cs.Music)music.GetSource());           
        public static void StopMusicStream(Music music) => Raylib.StopMusicStream((Raylib_cs.Music)music.GetSource());             
        public static void PauseMusicStream(Music music) => Raylib.PauseMusicStream((Raylib_cs.Music)music.GetSource());            
        public static void ResumeMusicStream(Music music) => Raylib.ResumeMusicStream((Raylib_cs.Music)music.GetSource());           
        public static bool IsMusicPlaying(Music music) => Raylib.IsMusicPlaying((Raylib_cs.Music)music.GetSource());              
        public static void SetMusicVolume(Music music, float volume) => Raylib.SetMusicVolume((Raylib_cs.Music)music.GetSource(), volume);
        public static void SetMusicPitch(Music music, float pitch) => Raylib.SetMusicPitch((Raylib_cs.Music)music.GetSource(), pitch);  
        public static float GetMusicTimeLength(Music music) => Raylib.GetMusicTimeLength((Raylib_cs.Music)music.GetSource());         
        public static float GetMusicTimePlayed(Music music) => Raylib.GetMusicTimePlayed((Raylib_cs.Music)music.GetSource()); 
        
        // AudioStream management functions
        public static AudioStream InitAudioStream(int sampleRate, int sampleSize, int channels) => RLSTMTOSTM(Raylib.InitAudioStream((uint)sampleRate, (uint)sampleSize, (uint)channels));
        public static void CloseAudioStream(AudioStream stream) => Raylib.CloseAudioStream((Raylib_cs.AudioStream)stream.GetSource());                                     
        public static bool IsAudioStreamProcessed(AudioStream stream) => Raylib.IsAudioStreamProcessed((Raylib_cs.AudioStream)stream.GetSource());                               
        public static void PlayAudioStream(AudioStream stream) => Raylib.PlayAudioStream((Raylib_cs.AudioStream)stream.GetSource());                                      
        public static void PauseAudioStream(AudioStream stream) => Raylib.PauseAudioStream((Raylib_cs.AudioStream)stream.GetSource());                                     
        public static void ResumeAudioStream(AudioStream stream) => Raylib.ResumeAudioStream((Raylib_cs.AudioStream)stream.GetSource());                                    
        public static bool IsAudioStreamPlaying(AudioStream stream) => Raylib.IsAudioStreamPlaying((Raylib_cs.AudioStream)stream.GetSource());                                 
        public static void StopAudioStream(AudioStream stream) => Raylib.StopAudioStream((Raylib_cs.AudioStream)stream.GetSource());                                      
        public static void SetAudioStreamVolume(AudioStream stream, float volume) => Raylib.SetAudioStreamVolume((Raylib_cs.AudioStream)stream.GetSource(), volume);                   
        public static void SetAudioStreamPitch(AudioStream stream, float pitch) => Raylib.SetAudioStreamPitch((Raylib_cs.AudioStream)stream.GetSource(), pitch);                     
        public static void SetAudioStreamBufferSizeDefault(int size) => Raylib.SetAudioStreamBufferSizeDefault(size);

        
        // structs -- or here classes
        public class Vector2
        {
            private System.Numerics.Vector2 v2;
            public float X { get { return v2.X; } set { v2.X = value; } }
            public float Y { get { return v2.Y; } set { v2.Y = value; } }

            public Vector2(float x, float y)
            {
                v2 = new System.Numerics.Vector2(x, y);
            }

            public void Add(Vector2 vec) => v2 += (snv2)vec.GetSource();
            public void Sub(Vector2 vec) => v2 -= (snv2)vec.GetSource();
            public void Mul(Vector2 vec) => v2 *= (snv2)vec.GetSource();
            public void Div(Vector2 vec) => v2 /= (snv2)vec.GetSource();
            public void MulF(float f) => v2 *= f;
            public void DivF(float f) => v2 /= f;
            public float Length() => v2.Length();
            public float LengthSquared() => v2.LengthSquared();
            public object GetSource() => v2;
        }
        
        public static Vector2 Vector2ZERO() => new Vector2(0f, 0f);
        public static Vector2 Vector2ONE() => new Vector2(1f, 1f);
        public static Vector2 Vector2X() => new Vector2(1f, 0f);
        public static Vector2 Vector2Y() => new Vector2(0f, 1f);
        
        public class Vector3
        {
            private System.Numerics.Vector3 v3;
            public float X { get { return v3.X; } set { v3.X = value; } }
            public float Y { get { return v3.Y; } set { v3.Y = value; } }
            public float Z { get { return v3.Z; } set { v3.Z = value; } }
            
            public Vector3(float x, float y, float z)
            {
                v3 = new System.Numerics.Vector3(x, y, z);
            }

            public void Add(Vector3 vec) => v3 += (snv3)vec.GetSource();
            public void Sub(Vector3 vec) => v3 -= (snv3)vec.GetSource();
            public void Mul(Vector3 vec) => v3 *= (snv3)vec.GetSource();
            public void Div(Vector3 vec) => v3 /= (snv3)vec.GetSource();
            public void MulF(float f) => v3 *= f;
            public void DivF(float f) => v3 /= f;
            public float Length() => v3.Length();
            public float LengthSquared() => v3.LengthSquared();
            public object GetSource() => v3;
        }
        
        public static Vector3 Vector3ZERO() => new Vector3(0f, 0f, 0f);
        public static Vector3 Vector3ONE() => new Vector3(1f, 1f, 1f);
        public static Vector3 Vector3X() => new Vector3(1f, 0f, 0f);
        public static Vector3 Vector3Y() => new Vector3(0f, 1f, 0f);
        public static Vector3 Vector3Z() => new Vector3(0f, 0f, 1f);
        
        public class Vector4
        {
            private System.Numerics.Vector4 v4;
            public float X { get { return v4.X; } set { v4.X = value; } }
            public float Y { get { return v4.Y; } set { v4.Y = value; } }
            public float Z { get { return v4.Z; } set { v4.Z = value; } }
            public float W { get { return v4.W; } set { v4.W = value; } }
            
            public Vector4(float x, float y, float z, float w)
            {
                v4 = new System.Numerics.Vector4(x, y, z, w);
            }

            public float Length() => v4.Length();
            public float LengthSquared() => v4.LengthSquared();
            public object GetSource() => v4;
        }
        
        public class Quaternion
        {
            private System.Numerics.Quaternion q;
            public float X { get { return q.X; } set { q.X = value; } }
            public float Y { get { return q.Y; } set { q.Y = value; } }
            public float Z { get { return q.Z; } set { q.Z = value; } }
            public float W { get { return q.W; } set { q.W = value; } }
            
            public Quaternion(float x, float y, float z, float w)
            {
                q = new System.Numerics.Quaternion(x, y, z, w);
            }

            public float Length() => q.Length();
            public float LengthSquared() => q.LengthSquared();
            public object GetSource() => q;
        }
        
        public class Matrix
        {
            private Matrix4x4 m;
            public float M11 { get { return m.M11; } set {m.M11 = value;}}
            public float M12 { get { return m.M12; } set {m.M12 = value;}}
            public float M13 { get { return m.M13; } set {m.M13 = value;}}
            public float M14 { get { return m.M14; } set {m.M14 = value;}}
            public float M21 { get { return m.M21; } set {m.M21 = value;}}
            public float M22 { get { return m.M22; } set {m.M22 = value;}}
            public float M23 { get { return m.M23; } set {m.M23 = value;}}
            public float M24 { get { return m.M24; } set {m.M24 = value;}}
            public float M31 { get { return m.M31; } set {m.M31 = value;}}
            public float M32 { get { return m.M32; } set {m.M32 = value;}}
            public float M33 { get { return m.M33; } set {m.M33 = value;}}
            public float M34 { get { return m.M34; } set {m.M34 = value;}}
            public float M41 { get { return m.M41; } set {m.M41 = value;}}
            public float M42 { get { return m.M42; } set {m.M42 = value;}}
            public float M43 { get { return m.M43; } set {m.M43 = value;}}
            public float M44 { get { return m.M44; } set {m.M44 = value;}}
            
            public Matrix()
            {
                m = new System.Numerics.Matrix4x4();
            }
            
            public float Length() => m.GetDeterminant();
            public bool LengthSquared() => m.IsIdentity;
            public object GetSource() => m;
            public object SetSource(object mat) => m = (System.Numerics.Matrix4x4)mat;
        }
        
        public class Color
        {
            private Raylib_cs.Color color;
            public int R { get { return color.r; } set { color.r = (byte)value; } }
            public int G { get { return color.g; } set { color.g = (byte)value; } }
            public int B { get { return color.b; } set { color.b = (byte)value; } }
            public int A { get { return color.a; } set { color.a = (byte)value; } }
            
            public Color(int r, int g, int b, int a)
            {
                color = new Raylib_cs.Color(r, g, b, a);
            }

            public object GetSource() => color;
        }
        
        public class Rectangle
        {
            private Raylib_cs.Rectangle rct;
            public float X => rct.x;
            public float Y => rct.y;
            public float W => rct.width;
            public float H => rct.height;

            public Rectangle(int x, int y, int w, int h)
            {
                rct = new Raylib_cs.Rectangle(x, y, w, h);
            }

            public object GetSource() => rct;
        }
        
        public class Image
        {
            private Raylib_cs.Image img;
            public int Width => img.width;
            public int Height => img.height;
            
            public Image()
            {
                img = new Raylib_cs.Image();
            }

            public unsafe Color get_Pixel(int x, int y)
            {
                Span<Color> rgba = new Span<Color>(img.data.ToPointer(), (img.width * img.height));
                var index = (y * img.width + x);
                return rgba[index];
            }
            
            public object GetSource() => img;
            public void SetSource(object image) => img = (Raylib_cs.Image)image;
        }
        
        public class Texture
        {
            private Raylib_cs.Texture2D tex;
            public int Width => tex.width;
            public int Height => tex.height;
            public int Mipmaps => tex.mipmaps;
            public int Id => (int)tex.id;

            public Texture()
            {
                tex = new Raylib_cs.Texture2D();
            }
            
            public object GetSource() => tex;
            public void SetSource(object texture) => tex = (Raylib_cs.Texture2D)texture;
        }
        
        public class RenderTexture
        {
            private Raylib_cs.RenderTexture2D tex;
            public int Id => (int)tex.id;
            public Texture Depth => RLTEXTOTEX(tex.depth);
            public Texture Texture => RLTEXTOTEX(tex.texture);

            public RenderTexture()
            {
                tex = new Raylib_cs.RenderTexture2D();
            }
            
            public object GetSource() => tex;
            public void SetSource(object texture) => tex = (Raylib_cs.RenderTexture2D)texture;
        }
        
        public class NPatchInfo
        {
            private Raylib_cs.NPatchInfo npi;
            public int Bottom => npi.bottom;
            public int Top => npi.top;
            public int Left => npi.left;
            public int Right => npi.right;
            
            public Rectangle SourceRect => RLRECTTORECT(npi.sourceRec);

            public NPatchInfo()
            {
                npi = new Raylib_cs.NPatchInfo();
            }
            
            public object GetSource() => npi;
            public void SetSource(object npain) => npi = (Raylib_cs.NPatchInfo)npain;
        }
        
        public class CharInfo
        {
            private Raylib_cs.CharInfo ci;
            public Image Image => RLIMGTOIMG(ci.image);
            public int Value => ci.value;
            public int AdvanceX => ci.advanceX;
            public int OffsetX => ci.offsetX;
            public int OffsetY => ci.offsetY;

            public CharInfo()
            {
                ci = new Raylib_cs.CharInfo();
            }
            
            public object GetSource() => ci;
            public void SetSource(object charinfo) => ci = (Raylib_cs.CharInfo)charinfo;
        }
        
        public class Font
        {
            private Raylib_cs.Font font;
            public Texture Texture => RLTEXTOTEX(font.texture);
            public int BaseSize => font.baseSize;
            public int CharsCount => font.charsCount;

            public Font()
            {
                font = new Raylib_cs.Font();
            }
            
            public object GetSource() => font;
            public void SetSource(object f) => font = (Raylib_cs.Font)f;
        }

        public class Camera
        {
            private Raylib_cs.Camera3D cam;
            public Vector3 Position { get { return RLV3TOV3(cam.position); } set { cam.position = (System.Numerics.Vector3) value.GetSource(); } }
            public Vector3 Target { get { return RLV3TOV3(cam.target); } set { cam.target = (System.Numerics.Vector3) value.GetSource(); } }
            public Vector3 Up { get { return RLV3TOV3(cam.up); } set { cam.up = (System.Numerics.Vector3) value.GetSource(); } }
            public float Fovy { get { return cam.fovy; } set { cam.fovy = value; } }
            public int Type { get { return (int)cam.type; } set { cam.type = (CameraType)value; } }

            public Camera()
            {
                cam = new Raylib_cs.Camera3D();
                cam.up = new System.Numerics.Vector3(0, 1f, 0);
                cam.fovy = 45.0f;
                cam.type = Raylib_cs.CameraType.CAMERA_PERSPECTIVE;
            }
            
            public object GetSource() => cam;
            public void SetSource(object c) => cam = (Raylib_cs.Camera3D)c;
        }
        
        public class Camera2D
        {
            private Raylib_cs.Camera2D cam;
            public float Zoom { get { return cam.zoom; } set { cam.zoom = value; } }
            public float Rotation { get { return cam.rotation; } set { cam.rotation = value; } }
            public Vector2 Offset { get { return RLV2TOV2(cam.offset); } set { cam.offset = (snv2)value.GetSource(); } }
            public Vector2 Target { get { return RLV2TOV2(cam.target); } set { cam.target = (snv2)value.GetSource(); } }

            public Camera2D()
            {
                cam = new Raylib_cs.Camera2D();
            }
            
            public object GetSource() => cam;
            public void SetSource(object c) => cam = (Raylib_cs.Camera2D)c;
        }

        public class Ray
        {
            private Raylib_cs.Ray ray;
            public Vector3 Position => RLV3TOV3(ray.position);
            public Vector3 Direction => RLV3TOV3(ray.direction);

            public Ray(Vector3 pos, Vector3 dir)
            {
                ray = new Raylib_cs.Ray((System.Numerics.Vector3)pos.GetSource(), (System.Numerics.Vector3)dir.GetSource());
            }
            
            public object GetSource() => ray;
            public void SetSource(object r) => ray = (Raylib_cs.Ray)r;
        }
        
        public class RayHitInfo
        {
            private Raylib_cs.RayHitInfo info;
            public float Distance => info.distance;
            public bool Hit => info.hit;
            public Vector3 Normal => RLV3TOV3(info.normal);
            public Vector3 Position => RLV3TOV3(info.position);

            public RayHitInfo()
            {
                info = new Raylib_cs.RayHitInfo();
            }
            
            public object GetSource() => info;
            public void SetSource(object r) => info = (Raylib_cs.RayHitInfo)r;
        }
        
        public class Mesh
        {
            private Raylib_cs.Mesh mesh;
            public int VertexCount => mesh.vertexCount;
            public int TriangleCount => mesh.triangleCount;

            public Mesh()
            {
                mesh = new Raylib_cs.Mesh();
            }

            public void AddColor(Color c)
            {
                Span<Raylib_cs.Color> colors;
                
                unsafe
                {
                    colors = new Span<Raylib_cs.Color>(mesh.colors.ToPointer(), mesh.vertexCount);
                }

                colors[mesh.vertexCount] = (Raylib_cs.Color)c.GetSource();
            }

            public void ClearColors()
            {
                unsafe
                {
                    Span<Raylib_cs.Color> colors = new Span<Raylib_cs.Color>(mesh.colors.ToPointer(), mesh.vertexCount);
                    colors.Clear();
                }
            }
            
            public unsafe void AddVertex(Vector3 v3)
            {
                snv3* pos;
                pos = (snv3*) mesh.vertices.ToPointer();
                
                pos[0] = (snv3)v3.GetSource();
            }

            public void ClearVertecies()
            {
                unsafe
                {
                    Span<snv3> pos = new Span<snv3>(mesh.vertices.ToPointer(), mesh.vertexCount);
                    pos.Clear();
                }
            }

            public object GetSource() => mesh;
            public void SetSource(object m) => mesh = (Raylib_cs.Mesh)m;
        }
        
        public class Shader
        {
            private Raylib_cs.Shader shdr;

            public Shader()
            {
                shdr = new Raylib_cs.Shader();
            }

            public unsafe void set_Loc(int index, int val)
            {
                Span<int> locs = new Span<int>(shdr.locs.ToPointer(), 25);
                locs[index] = val;
            }
            
            public unsafe void set_LocS(string index, int val)
            {
                Span<int> locs = new Span<int>(shdr.locs.ToPointer(), 25);
                locs[(int)Enum.Parse(typeof(ShaderLocationIndex), index)] = val;
            }

            public object GetSource() => shdr;
            public void SetSource(object s) => shdr = (Raylib_cs.Shader)s;
        }
        
        public class Material
        {
            private Raylib_cs.Material mat;

            public Material()
            {
                mat = new Raylib_cs.Material();
            }
            
            public object GetSource() => mat;
            public void SetSource(object m) => mat = (Raylib_cs.Material)m;
        }
        
        public class Model
        {
            private Raylib_cs.Model model;

            public Model()
            {
                model = new Raylib_cs.Model();
            }

            public unsafe void set_Shader(Shader s)
            {
                Span<Raylib_cs.Material> mats = new Span<Raylib_cs.Material>(model.materials.ToPointer(), 1);
                mats[0].shader = (Raylib_cs.Shader) s.GetSource();
            }

            public unsafe void set_Texture(Texture tex)
            {
                Span<Raylib_cs.Material> mats = new Span<Raylib_cs.Material>(model.materials.ToPointer(), 1);
                Span<Texture2D> texs = new Span<Texture2D>(mats[0].maps.ToPointer(), 11);
                texs[(int)MaterialMapType.MAP_ALBEDO] = (Texture2D)tex.GetSource();
            }
            
            public object GetSource() => model;
            public void SetSource(object m) => model = (Raylib_cs.Model)m;
        }
        
        public class BoundingBox
        {
            private Raylib_cs.BoundingBox box;

            public BoundingBox()
            {
                box = new Raylib_cs.BoundingBox();
            }
            
            public object GetSource() => box;
            public void SetSource(object b) => box = (Raylib_cs.BoundingBox)b;
        }
        

        public class Wave
        {
            private Raylib_cs.Wave wav;
            public int Channels => (int)wav.channels;
            public int SampleCount => (int)wav.sampleCount;
            public int SampleRate => (int)wav.sampleRate;
            public int SampleSize => (int)wav.sampleSize;

            public Wave()
            {
                wav = new Raylib_cs.Wave();
            }
            
            public object GetSource() => wav;
            public void SetSource(object w) => wav = (Raylib_cs.Wave)w;
        }
        
        public class AudioStream
        {
            private Raylib_cs.AudioStream strm;
            public int Channels => (int)strm.channels;
            public int SampleRate => (int)strm.sampleRate;
            public int SampleSize => (int)strm.sampleSize;
            
            public AudioStream()
            {
                strm = new Raylib_cs.AudioStream();
            }
            
            public object GetSource() => strm;
            public void SetSource(object s) => strm = (Raylib_cs.AudioStream)s;
        }
        
        public class Sound
        {
            private Raylib_cs.Sound snd;
            public int SampleCount => (int)snd.sampleCount;
            public AudioStream Stream => RLSTMTOSTM(snd.stream);

            public Sound()
            {
                snd = new Raylib_cs.Sound();
            }
            
            public object GetSource() => snd;
            public void SetSource(object b) => snd = (Raylib_cs.Sound)b;
        }
        
        public class Music
        {
            private Raylib_cs.Music mus;
            public bool Looing { get { return mus.looping; } set { mus.looping = value; }}
            public AudioStream Stream => RLSTMTOSTM(mus.stream);
            public int SampleCount => (int)mus.sampleCount;
            public int CtxType => (int)mus.ctxType;
            
            public Music()
            {
                mus = new Raylib_cs.Music();
            }
            
            public object GetSource() => mus;
            public void SetSource(object m) => mus = (Raylib_cs.Music)m;
        }

        public class VrDeviceInfo
        {
            private Raylib_cs.VrDeviceInfo info;
            public int hResolution { get { return info.hResolution; } set { info.hResolution = value; } }
            public int vResolution { get { return info.vResolution; } set { info.vResolution = value; } }
            public float interpupillaryDistance { get { return info.interpupillaryDistance; } set { info.interpupillaryDistance = value; } }
            public float[] chromaAbCorrection { get { return info.chromaAbCorrection; } set { info.chromaAbCorrection = value; } }
            public float hScreenSize { get { return info.hScreenSize; } set { info.hScreenSize = value; } }
            public float vScreenSize { get { return info.vScreenSize; } set { info.vScreenSize = value; } }
            public float[] lensDistortionValues { get { return info.lensDistortionValues; } set { info.lensDistortionValues = value; } }
            public float lensSeparationDistance { get { return info.lensSeparationDistance; } set { info.lensSeparationDistance = value; } }
            public float vScreenCenter { get { return info.vScreenCenter; } set { info.vScreenCenter = value; } }
            public float eyeToScreenDistance { get { return info.eyeToScreenDistance; } set { info.eyeToScreenDistance = value; } }

            public VrDeviceInfo()
            {
                info = new Raylib_cs.VrDeviceInfo();
            }
            
            public object GetSource() => info;
            public void SetSource(object i) => info = (Raylib_cs.VrDeviceInfo)i;
        }

        //class utils
        public class MeshBuilder
        {
            private RLSharpMeshGen.MeshBuilder mb;
            public bool get_Bound() => mb.Bound();
        
            public MeshBuilder()
            {
                mb = new RLSharpMeshGen.MeshBuilder();
            }

            public void Begin(int tris, bool colors, bool uvs, bool uv2s) => mb.Begin(tris, colors, uvs, uv2s);
            public void AddTriangle(rlv3 aV, rlv3 aNor, rlv2 aUV, rlv3 bV, rlv3 bNor, rlv2 bUV, rlv3 cV, rlv3 cNor, rlv2 cUV)
                => mb.AddTriangle((snv3)aV.GetSource(), (snv3)aNor.GetSource(), (snv2)aUV.GetSource(), (snv3)bV.GetSource(), (snv3)bNor.GetSource(), (snv2)bUV.GetSource(), (snv3)cV.GetSource(), (snv3)cNor.GetSource(), (snv2)cUV.GetSource());
            //public void AddTriangleCol(rlv3 aV, rlv3 aNor, rlv2 aUV, col aCol, rlv3 bV, rlv3 bNor, rlv2 bUV, col bCol, rlv3 cV, rlv3 cNor, rlv2 cUV, col cCol)
            //=> mb.AddTriangle((snv3)aV.GetSource(), (snv3)aNor.GetSource(), (snv2)aUV.GetSource(), (co)aCol.GetSource(), (snv3)bV.GetSource(), (snv3)bNor.GetSource(), (snv2)bUV.GetSource(), (co)bCol.GetSource(), (snv3)cV.GetSource(), (snv3)cNor.GetSource(), (snv2)cUV.GetSource(), (co)cCol.GetSource());
            public Relib.Mesh Bind()
            {
                mb.Bind();
                return Relib.RLMESHTOMESH(mb.Mesh);
            }
        }
        
        // utils
        private static Vector2 RLV2TOV2(System.Numerics.Vector2 _v2)
        {
            return new Vector2(_v2.X, _v2.Y);
        }

        private static Vector3 RLV3TOV3(System.Numerics.Vector3 _v3)
        {
            return new Vector3(_v3.X, _v3.Y, _v3.Z);
        }
        
        private static Vector4 RLV4TOV4(System.Numerics.Vector4 _v4)
        {
            return new Vector4(_v4.X, _v4.Y, _v4.Z, _v4.W);
        }
        
        private static Color RLCOLTOCOL(Raylib_cs.Color col)
        {
            return new Color(col.r, col.g, col.b, col.a);
        }
        
        private static Image RLIMGTOIMG(Raylib_cs.Image _img)
        {
            var img = new Image();
            img.SetSource(_img);
            return img;
        }
        
        private static Texture RLTEXTOTEX(Raylib_cs.Texture2D _tex)
        {
            var tex = new Texture();
            tex.SetSource(_tex);
            return tex;
        }
        
        private static RenderTexture RLRTEXTORTEX(Raylib_cs.RenderTexture2D _tex)
        {
            var tex = new RenderTexture();
            tex.SetSource(_tex);
            return tex;
        }

        private static Rectangle RLRECTTORECT(Raylib_cs.Rectangle rct)
        {
            return new Rectangle((int) rct.x, (int) rct.y, (int) rct.width, (int) rct.height);
        }
        
        private static Camera RLCAMTOCAM(Raylib_cs.Camera3D c)
        {
            var cam = new Camera();
            cam.SetSource(c);
            return cam;
        }
        
        private static Material RLMATTOMAT(Raylib_cs.Material m)
        {
            var mat = new Material();
            mat.SetSource(m);
            return mat;
        }
        
        private static Model RLMODTOMOD(Raylib_cs.Model m)
        {
            var mod = new Model();
            mod.SetSource(m);
            return mod;
        }
        
        private static Shader RLSHTOSH(Raylib_cs.Shader s)
        {
            var sh = new Shader();
            sh.SetSource(s);
            return sh;
        }
        
        public static Mesh RLMESHTOMESH(Raylib_cs.Mesh m)
        {
            var mesh = new Mesh();
            mesh.SetSource(m);
            return mesh;
        }
        
        private static Ray RLRAYTORAY(Raylib_cs.Ray r)
        {
            var ray = new Ray(new Vector3(0,0,0), new Vector3(0,0,0));
            ray.SetSource(r);
            return ray;
        }
        
        private static RayHitInfo RLRINFOTORINFO(Raylib_cs.RayHitInfo i)
        {
            var info = new RayHitInfo();
            info.SetSource(i);
            return info;
        }
        
        private static Matrix RLMATRTOMATR(System.Numerics.Matrix4x4 m)
        {
            var mat = new Matrix();
            mat.SetSource(m);
            return mat;
        }
        
        private static Font RLFNTTOFNT(Raylib_cs.Font f)
        {
            var fnt = new Font();
            fnt.SetSource(f);
            return fnt;
        }
        
        private static BoundingBox RLBDBTOBDB(Raylib_cs.BoundingBox b)
        {
            var box = new BoundingBox();
            box.SetSource(b);
            return box;
        }
        
        private static Wave RLWAVTOWAV(Raylib_cs.Wave w)
        {
            var wav = new Wave();
            wav.SetSource(w);
            return wav;
        }
        
        private static Sound RLSNDTOSND(Raylib_cs.Sound s)
        {
            var snd = new Sound();
            snd.SetSource(s);
            return snd;
        }
        
        private static AudioStream RLSTMTOSTM(Raylib_cs.AudioStream s)
        {
            var str = new AudioStream();
            str.SetSource(s);
            return str;
        }
        
        private static Music RLMUSTOMUS(Raylib_cs.Music m)
        {
            var mus = new Music();
            mus.SetSource(m);
            return mus;
        }
    }
}
