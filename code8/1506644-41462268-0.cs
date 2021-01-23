    public static class WindowExtensions
    {
        private const int GCL_HBRBACKGROUND = -10;
        private const int COLOR_WINDOW = 5;
        public static void SetClassLong(this Window window)
        {
            //change the background colour of the window to "hide" possible black rendering artifacts
            IntPtr handle = new WindowInteropHelper(window).EnsureHandle();
            if (handle != IntPtr.Zero)
                SetClassLong(handle, GCL_HBRBACKGROUND, SafeNativeMethods.GetSysColorBrush(COLOR_WINDOW));
        }
        private static IntPtr SetClassLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size > 4)
                return SafeNativeMethods.SetClassLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SafeNativeMethods.SetClassLongPtr32(hWnd, nIndex, unchecked((uint)dwNewLong.ToInt32())));
        }
    }
    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            //change the background colour of the window to "hide" possible black rendering artifacts
            this.SetClassLong();
        }
    }
