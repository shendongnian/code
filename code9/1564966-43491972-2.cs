    public partial class Form1 : Form
    {
        delegate bool EnumWindowsProc(IntPtr Hwnd, IntPtr lParam);
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool EnumThreadWindows(int threadId, EnumWindowsProc callback, IntPtr lParam);
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        private extern static int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        private const int WM_CLOSE = 0x10;
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Form2();
            frm.Show(this);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("FindWindowSample");
            foreach (Process p in processes)
            {
                var handle = FindWindowInProcess(p, x => x == "Form2");
                if (handle != IntPtr.Zero)
                {
                    SendMessage(handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
            }
        }
        public static IntPtr FindWindowInProcess(Process process, Func<string, bool> compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;
            foreach (ProcessThread t in process.Threads)
            {
                windowHandle = FindWindowInThread(t.Id, compareTitle);
                if (windowHandle != IntPtr.Zero)
                {
                    break;
                }
            }
            return windowHandle;
        }
        private static IntPtr FindWindowInThread(int threadId, Func<string, bool> compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;
            EnumThreadWindows(threadId, (hWnd, lParam) =>
            {
                StringBuilder text = new StringBuilder(200);
                GetWindowText(hWnd, text, 200);
                if (compareTitle(text.ToString()))
                {
                    windowHandle = hWnd;
                    return false;
                }
                return true;
            }, IntPtr.Zero);
            return windowHandle;
        }
    }
