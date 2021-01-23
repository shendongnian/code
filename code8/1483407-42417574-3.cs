    public partial class MainWindow : Window
    { 
        private const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
        private const int DWM_BB_ENABLE = 0x1; 
        [StructLayout(LayoutKind.Sequential)]
        private struct DWM_BLURBEHIND
        {
            public int dwFlags;
            public bool fEnable;
            public IntPtr hRgnBlur;
            public bool fTransitionOnMaximized;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        } 
        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern void DwmEnableBlurBehindWindow(IntPtr hwnd, ref DWM_BLURBEHIND blurBehind);
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);
        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern bool DwmIsCompositionEnabled();
 
        public MainWindow()
        { 
            InitializeComponent();
            SourceInitialized += OnSourceInitialized; 
        } 
        private void OnSourceInitialized(object sender, EventArgs eventArgs)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            var hs = HwndSource.FromHwnd(hwnd);
            hs.CompositionTarget.BackgroundColor = System.Windows.Media.Colors.Transparent;
             
            var margins = new MARGINS();
            margins.cxLeftWidth = margins.cxRightWidth = margins.cyTopHeight = margins.cyBottomHeight = -1;
            DwmExtendFrameIntoClientArea(hwnd, ref margins);
             
            DWM_BLURBEHIND bbh = new DWM_BLURBEHIND();
            bbh.fEnable = true;
            bbh.dwFlags = DWM_BB_ENABLE;
            DwmEnableBlurBehindWindow(hwnd, ref bbh);
        }
 
        private void TriggerMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }
        private void TriggerMoveWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == System.Windows.WindowState.Maximized)
                {
                    WindowState = System.Windows.WindowState.Normal; 
                    double pct = PointToScreen(e.GetPosition(this)).X / System.Windows.SystemParameters.PrimaryScreenWidth;
                    Top = 0;
                    Left = e.GetPosition(this).X - (pct * Width);
                }
                Application.Current.MainWindow.DragMove();
            }
        }
        private void TriggerMaximize(object sender, EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Maximized)
            {
                WindowState = System.Windows.WindowState.Normal;
                btnMaximize.FontFamily = new System.Windows.Media.FontFamily("Webdings");
                btnMaximize.Content = "c";
            }
            else if (WindowState == System.Windows.WindowState.Normal)
            {
                WindowState = System.Windows.WindowState.Maximized;
                btnMaximize.FontFamily = new System.Windows.Media.FontFamily("Wingdings");
                btnMaximize.Content = "r";
                InvalidateVisual();
            }
        }
        private void TriggerClose(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            this.Height += e.VerticalChange;
            this.Width += e.HorizontalChange;
        }
    }
    
