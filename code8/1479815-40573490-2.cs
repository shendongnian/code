    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication13
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                OpenFileDialog dlg = new OpenFileDialog();
    
                //start a thread to change the dialog path just before displaying it to the user
                Thread posThread = new Thread(setDialogPath);
                posThread.Start();
    
                //display dialog to the user
                DialogResult dr = dlg.ShowDialog();
            }
    
            [DllImport("user32.dll")]
            static extern IntPtr FindWindow(IntPtr lpClassName, string lpWindowName);
            [DllImport("user32.dll")]
            static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);
            [DllImport("user32.dll")]
            static extern IntPtr PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
            [DllImport("user32.Dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);
    
            private void setDialogPath()
            {
                const string FULL_PATH = "C:\\Users\\Public\\Documents";
    
                //messages
                const int WM_SETTEXT = 0xC;
                const int WM_KEYDOWN = 0x100;
                const int WM_KEYUP = 0x101;
                //enter key code
                const int VK_RETURN = 0x0D;
    
                //dialog box window handle
                IntPtr _window_hwnd;
    
                //how many attempts to detect the window
                int _attempts_count = 0;
    
                //get the dialog window handle
                while ((_window_hwnd = FindWindow(IntPtr.Zero, "Open")) == IntPtr.Zero)
                    if (++_attempts_count > 100)
                        return;
                    else
                        Thread.Sleep(500); //try again
    
                //in it - find the path textbox's handle.
                var hwndChild = EnumAllWindows(_window_hwnd, "Edit").FirstOrDefault();
    
                //set the path
                SendMessage(hwndChild, WM_SETTEXT, 0, FULL_PATH);
    
                //apply the path (send 'enter' to the textbox)
                PostMessage(hwndChild, WM_KEYDOWN, VK_RETURN, 0);
                PostMessage(hwndChild, WM_KEYUP, VK_RETURN, 0);
            }
    
    
            public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);
    
            private static bool EnumWindow(IntPtr handle, IntPtr pointer)
            {
                GCHandle gch = GCHandle.FromIntPtr(pointer);
                List<IntPtr> list = gch.Target as List<IntPtr>;
                if (list == null)
                    throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
                list.Add(handle);
                return true;
            }
    
            public static List<IntPtr> GetChildWindows(IntPtr parent)
            {
                List<IntPtr> result = new List<IntPtr>();
                GCHandle listHandle = GCHandle.Alloc(result);
                try
                {
                    Win32Callback childProc = new Win32Callback(EnumWindow);
                    EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
                }
                finally
                {
                    if (listHandle.IsAllocated)
                        listHandle.Free();
                }
                return result;
            }
    
            public static string GetWinClass(IntPtr hwnd)
            {
                if (hwnd == IntPtr.Zero)
                    return null;
                StringBuilder classname = new StringBuilder(100);
                IntPtr result = GetClassName(hwnd, classname, classname.Capacity);
                if (result != IntPtr.Zero)
                    return classname.ToString();
                return null;
            }
    
            public static IEnumerable<IntPtr> EnumAllWindows(IntPtr hwnd, string childClassName)
            {
                List<IntPtr> children = GetChildWindows(hwnd);
                if (children == null)
                    yield break;
                foreach (IntPtr child in children)
                {
                    if (GetWinClass(child) == childClassName)
                        yield return child;
                    foreach (var childchild in EnumAllWindows(child, childClassName))
                        yield return childchild;
                }
            }
    
        }
    }
