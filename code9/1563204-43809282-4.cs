    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            host = new System.Windows.Forms.Integration.WindowsFormsHost();
            var mtbDate = new System.Windows.Forms.MaskedTextBox("00/00/0000");
            host.Child = mtbDate;
            host.IsKeyboardFocusWithinChanged += Host_IsKeyboardFocusWithinChanged;
            stackPanel1.Children.Add(host);
            textBox1 = new TextBox();
            stackPanel1.Children.Add(textBox1);
            textBox2 = new TextBox();
            stackPanel1.Children.Add(textBox2);
        }
        private void Host_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine(host.IsKeyboardFocusWithin.ToString() + " blah");
            textBox1.Text = $"Host.IsKeyboardFocusedWithin = {host.IsKeyboardFocusWithin}";
        }
        private System.Windows.Forms.Integration.WindowsFormsHost host;
        private TextBox textBox1;
        private TextBox textBox2;
        private void Window_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine(IsKeyboardFocusWithin.ToString());
            textBox2.Text = $"Window.IsKeyboardFocusedWithin = {IsKeyboardFocusWithin}";
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
                //suppress kill focus message if host has keyboardfocus, else don't
                handled = host.IsKeyboardFocusWithin;
            }
            else if (msg == WM_ACTIVATEAPP && wParam.ToInt32() == WM_PARAM_FALSE)
            {
                //now the kill focus could be suppressed event during window switch, which we want to avoid
                //so we make sure that the host control property is updated by traversal (or any other method)
                if (host.IsKeyboardFocusWithin)
                {
                    host.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
            }
            return IntPtr.Zero;
        }
    }
