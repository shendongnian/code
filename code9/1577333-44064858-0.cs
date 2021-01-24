    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApp1
    {
    
        public class EnumerateWindowsTest
        {
    
            [StructLayout(LayoutKind.Sequential)]
            public struct Rect
            {
                public int Left;        // x position of upper-left corner
                public int Top;         // y position of upper-left corner
                public int Right;       // x position of lower-right corner
                public int Bottom;      // y position of lower-right corner
            }
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
    
            [DllImport("user32.dll")]
            static extern IntPtr GetShellWindow();
    
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern int GetWindowTextLength(IntPtr hWnd);
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
            public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
            [DllImport("user32.dll")]
            static extern int EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool IsWindowVisible(IntPtr hWnd);
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool IsIconic(IntPtr hWnd);
            [DllImport("user32.dll", SetLastError = true)]
            static extern System.UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
    
    
            internal static List<DetectedWindow> EnumerateWindows()
            {
                var shellWindow = GetShellWindow();
                var windows = new List<DetectedWindow>();
                EnumWindows(delegate (IntPtr handle, IntPtr lParam)
                {
    
                    if (handle == shellWindow)
                        return true;
    
                    if (!IsWindowVisible(handle))
                        return true;
    
                    if (IsIconic(handle))
                        return true;
    
                    if (HasSomeExtendedWindowsStyles(handle))
                        return true;
    
                    var length = GetWindowTextLength(handle);
    
                    if (length == 0)
                        return true;
    
                    var builder = new StringBuilder(length);
    
                    GetWindowText(handle, builder, length + 1);
                    GetWindowRect(handle, out Rect rect);
                    windows.Add(new DetectedWindow(handle, rect, builder.ToString()));
    
                    return true;
                }, IntPtr.Zero);
    
                return windows;
            }
    
            static bool HasSomeExtendedWindowsStyles(IntPtr hwnd)
            {
                const int GWL_EXSTYLE = -20;
                const uint WS_EX_TOOLWINDOW = 0x00000080U;
    
                uint i = GetWindowLong(hwnd, GWL_EXSTYLE);
                if ((i & (WS_EX_TOOLWINDOW)) != 0)
                {
                    return true;
                }
    
                return false;
            }
    
        }
    
        public class DetectedWindow
        {
            public IntPtr Handle { get; private set; }
    
            public EnumerateWindowsTest.Rect Bounds { get; private set; }
    
            public string Name { get; private set; }
    
            public DetectedWindow(IntPtr handle, EnumerateWindowsTest.Rect bounds, string name)
            {
                Handle = handle;
                Bounds = bounds;
                Name = name;
            }
        }
        
    
    
        class Program
        {
    
            static void DetectWindows()
            {
                foreach (DetectedWindow w in EnumerateWindowsTest.EnumerateWindows())
                {
                    Console.WriteLine("{0} - {1};{2};{3};{4}",w.Name,w.Bounds.Left,w.Bounds.Top,w.Bounds.Right,w.Bounds.Bottom);
                }
            }
    
            static void Main(string[] args)
            {
                DetectWindows();
                Console.ReadLine();
            }
        }
    
    
    }
