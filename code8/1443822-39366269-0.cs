    partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
    
            _isMaximized = WindowState == FormWindowState.Maximized;
        }
    
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                int wparam = m.WParam.ToInt32() & 0xfff0;
                if (wparam == SC_MAXIMIZE)
                    _isMaximized = true;
                else if (wparam == SC_RESTORE)
                    _isMaximized = false;
            }
    
            base.WndProc(ref m);
        }
    
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MAXIMIZE = 0xf030;
        private const int SC_RESTORE = 0xf120;
        private bool _isMaximized;
    }
