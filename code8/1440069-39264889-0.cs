    public partial class MainWindow : Window
    {
    [DllImport("user32.dll")]
    static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    [DllImport("user32.dll")]
    static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);
    const uint MF_BYCOMMAND = 0x00000000;
    const uint MF_GRAYED = 0x00000001;
    const uint MF_ENABLED = 0x00000000;
    const uint SC_CLOSE = 0xF060;
    const int WM_SHOWWINDOW = 0x00000018;
    const int WM_CLOSE = 0x10;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
    }
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
        if (hwndSource != null)
        {
            hwndSource.AddHook(new HwndSourceHook(this.hwndSourceHook));
        }
    }
    IntPtr hwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == WM_SHOWWINDOW)
        {
            IntPtr hMenu = GetSystemMenu(hwnd, false);
            if (hMenu != IntPtr.Zero)
            {
                EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
            }
        }
        else if (msg == WM_CLOSE)
        {
            handled = true;
        }
        return IntPtr.Zero;
      }
    }
