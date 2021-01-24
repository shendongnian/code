    public partial class MainWindow : Window
    { 
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetKeyboardLayout(uint idThread);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr processId);
        public MainWindow()
        {  
            InitializeComponent();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    HandleCurrentLanguage();
                    System.Threading.Thread.Sleep(500);
                }
            }); 
        }
        IntPtr _currentKeyboardLayout = IntPtr.Zero;
        private void HandleCurrentLanguage()
        {
            var newLayout = GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
            if (_currentKeyboardLayout != newLayout)
            {
                _currentKeyboardLayout = newLayout;
                // do something 
            }
        }  
    }
 
