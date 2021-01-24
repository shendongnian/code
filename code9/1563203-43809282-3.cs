    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateControls();
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }
        private const int WM_KILLFOCUS = 0x0008;
        private const int WM_ACTIVATEAPP = 0x001c;
        private const int WM_PARAM_FALSE = 0x00000000;
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Handle messages...
            if (msg == WM_KILLFOCUS)
            {
                Console.WriteLine(wParam + " " + lParam);
                //suppress kill focus message if host has keyboardfocus, else don't
                var hosts = FindVisualChildren<WindowsFormsHost>(this);
                var focusedControlHwnd = wParam.ToInt32();
                if(focusedControlHwnd != 0)
                {
                    handled = hosts.Any(x => x.Child.Handle.ToInt32() == focusedControlHwnd);
                }
            }
            else if (msg == WM_ACTIVATEAPP && wParam.ToInt32() == WM_PARAM_FALSE)
            {
                //now the kill focus could be suppressed event during window switch, which we want to avoid
                //so we make sure that the host control property is updated 
                var hosts = FindVisualChildren<WindowsFormsHost>(this);
                if (hosts.Any(x => x.IsKeyboardFocusWithin))
                    hiddenBtn.Focus();
            }
            return IntPtr.Zero;
        }
        private void GenerateControls()
        {
            System.Windows.Forms.MaskedTextBox maskedTextBox;
            System.Windows.Forms.Integration.WindowsFormsHost host;
            host = new System.Windows.Forms.Integration.WindowsFormsHost();
            maskedTextBox = new System.Windows.Forms.MaskedTextBox("00/00/0000");
            host.Child = maskedTextBox;
            rightPanel.Children.Add(new Border() { Child = host });
            host = new System.Windows.Forms.Integration.WindowsFormsHost();
            maskedTextBox = new System.Windows.Forms.MaskedTextBox("00/00/0000");
            host.Child = maskedTextBox;
            rightPanel.Children.Add(new Border() { Child = host });
            host = new System.Windows.Forms.Integration.WindowsFormsHost();
            maskedTextBox = new System.Windows.Forms.MaskedTextBox("(000)-000-0000");
            host.Child = maskedTextBox;
            rightPanel.Children.Add(new Border() { Child = host });
            host = new System.Windows.Forms.Integration.WindowsFormsHost();
            maskedTextBox = new System.Windows.Forms.MaskedTextBox("00000");
            host.Child = maskedTextBox;
            rightPanel.Children.Add(new Border() { Child = host });
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
