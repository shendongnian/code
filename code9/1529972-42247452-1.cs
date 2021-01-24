    public partial class PowerPointViewer : Window
    {
        Process proc = new Process();
        Window main;
        public PowerPointViewer(Window main)
        {
            InitializeComponent();
            this.main = main;
        }
        public void open(string source)
        {
            proc.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft Office\Office14\POWERPNT.EXE";
            proc.StartInfo.Arguments = " /s " + source;
            proc.Start();
            Show();
        }
        private void bt_close_Click(object sender, RoutedEventArgs e)
        {
            if (!proc.HasExited)
                proc.Kill();
            Close();
            main.Focus();
        }
    }
