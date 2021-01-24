    public partial class Dialog : Window
    {
        public Dialog()
        {
            InitializeComponent();
        }
    
        public Dialog(MainWindow main)
            : this()
        {
            _main = main;
        }
    
        private void Dialog_OnActivated(object sender, EventArgs e)
        {
            Topmost = _main.Topmost = true;
        }
    
        private void Dialog_OnDeactivated(object sender, EventArgs e)
        {
            Topmost = _main.Topmost = false;
        }
    
        private readonly MainWindow _main;
