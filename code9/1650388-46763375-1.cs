    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // Call Dispose to remove the icon out of notification area of Taskbar.
            notifyIcon1.Dispose();
        }
    }
