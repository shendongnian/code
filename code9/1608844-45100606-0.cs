    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace myScreenCapture
    {
        public enum CaptureMode
        {
            Screen, Window
        }
    
        public static class ScreenCapturer
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
    
            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
    
            [StructLayout(LayoutKind.Sequential)]
            private struct Rect
            {
                public int Left, Top, Right, Bottom;
            }
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetDesktopWindow();
    
            public static void CaptureAndSave(string filename, string path, CaptureMode mode = CaptureMode.Window, ImageFormat format = null)
            {
                ImageSave(filename, format, Capture(mode), path);
            }
    
            public static void CaptureAndSave(string filename, IntPtr handle, string path, ImageFormat format = null)
            {
                ImageSave(filename, format, Capture(handle), path);
            }
    
            public static void CaptureAndSave(string filename, Control c, string path, ImageFormat format = null)
            {
                ImageSave(filename, format, Capture(c), path);
            }
            
            public static Bitmap Capture(CaptureMode mode = CaptureMode.Window)
            {
                return Capture(mode == CaptureMode.Screen ? GetDesktopWindow() : GetForegroundWindow());
            }
    
            
            public static Bitmap Capture(Control c)
            {
                return Capture(c.Handle);
            }
    
            public static Bitmap Capture(IntPtr handle)
            {
                Rectangle bounds;
                var rect = new Rect();
                GetWindowRect(handle, ref rect);
                bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                CursorPosition = new Point(Cursor.Position.X - rect.Left, Cursor.Position.Y - rect.Top);
    
                var result = new Bitmap(bounds.Width, bounds.Height);
                using (var g = Graphics.FromImage(result))
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
    
                return result;
            }
    
            /// <summary> Position of the cursor relative to the start of the capture </summary>
            public static Point CursorPosition;
    
            static void ImageSave(string filename, ImageFormat format, Image image, string path)
            {
                format = format ?? ImageFormat.Png;
                if (!filename.Contains("."))
                    filename = filename.Trim() + "." + format.ToString().ToLower();
    
                if (!filename.Contains(@"\"))
                {
                    // filename = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? @"C:\Temp", filename);
                    filename = Path.Combine(path, filename);
                }
    
                filename = filename.Replace("%NOW%", DateTime.Now.ToString("yyyy-MM-dd@hh.mm.ss"));
                image.Save(filename, format);
            }
        }
    }
