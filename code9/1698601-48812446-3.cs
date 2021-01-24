    namespace OnScreenOverlay
    {
    public partial class Overlay : Form
    {
        #region Public Fields
        public const string UserCache = @"redacted";
        #endregion Public Fields
        #region Private Fields
        private const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B;
        private const uint WINEVENT_OUTOFCONTEXT = 0x0000;
        private const uint WINEVENT_SKIPOWNPROCESS = 0x0002;
        private const uint WINEVENT_SKIPOWNTHREAD = 0x0001;
        private readonly Process _foxview;
        private readonly IntPtr _foxViewHWnd;
        private readonly UserMon _monitor;
        private string _currentUser;
        #endregion Private Fields
        #region Public Constructors
        public Overlay()
        {
            InitializeComponent();
            _target= Process.GetProcessesByName("target")[0];
            if (_foxview == null)
            {
                MessageBox.Show("No target detected... Closing");
                Close();
            }
            _targetHWnd = _target.MainWindowHandle;
            InitializeWinHook();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.Bounds.Left + 20, Screen.PrimaryScreen.Bounds.Bottom - 20);
            ShowInTaskbar = false;
            _monitor = new UserMon(UserCache);
            _monitor.UserChanged += (s, a) =>
            {
                _currentUser = a.Value;
                if (pictBox.InvokeRequired)
                {
                    pictBox.Invoke((MethodInvoker)delegate { pictBox.Refresh(); });
                }
            };
            _currentUser = _monitor.GetUser();
        }
        #endregion Public Constructors
        #region Private Delegates
        private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
                            IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
        #endregion Private Delegates
        #region Private Methods
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rect lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr processId);
        [DllImport("user32.dll")]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
                hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
            uint idThread, uint dwFlags);
        private void InitializeWinHook()
        {
            SetWinEventHook(EVENT_OBJECT_LOCATIONCHANGE, EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, TargetMoved, (uint)_foxview.Id,
                GetWindowThreadProcessId(_foxview.MainWindowHandle, IntPtr.Zero), WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS | WINEVENT_SKIPOWNTHREAD);
        }
        private void Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            _monitor.Dispose();
        }
        private void pictBox_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Arial", 8))
            {
                e.Graphics.DrawString($"User: {_currentUser}", myFont, Brushes.LimeGreen, new Point(2, 2));
            }
        }
        private void TargetMoved(IntPtr hWinEventHook, uint eventType, IntPtr lParam, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            Rect newLocation = new Rect();
            GetWindowRect(_foxViewHWnd, ref newLocation);
            Location = new Point(newLocation.Right - (250 + _currentUser.Length * 7), newLocation.Top + 5);
        }
        #endregion Private Methods
        #region Private Structs
        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public readonly int Left;
            public readonly int Top;
            public readonly int Right;
            public readonly int Bottom;
        }
        #endregion Private Structs
    }
    }
