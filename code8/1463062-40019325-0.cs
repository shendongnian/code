    public partial class MainWindow : Window
    {
        private IKeyboardMouseEvents m_GlobalHook;
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        protected override void OnSourceInitialized(EventArgs e)
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseClick += m_GlobalHook_MouseClick;
    
            base.OnSourceInitialized(e);
        }
    
        private void m_GlobalHook_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                tblock.Text += "Middle mouse button clicked" + Environment.NewLine;
            }
        }
    
        protected override void OnClosed(EventArgs e)
        {
            m_GlobalHook.MouseClick -= m_GlobalHook_MouseClick;
            m_GlobalHook.Dispose();
                
            base.OnClosed(e);
        }
    }
