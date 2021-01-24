    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Activated += CurrentOnActivated;
            Application.Current.Deactivated += CurrentOnDeactivated;
            
        }
        private bool isDeactivated = true;
        private void CurrentOnDeactivated(object sender, EventArgs eventArgs)
        {
            isDeactivated = true;
            //handle case where another app gets focus
        }
        private void CurrentOnActivated(object sender, EventArgs eventArgs)
        {
            if (isDeactivated)
            {
                //Ok, this app was in the background but now is in the foreground,
                isDeactivated = false;
                //TODO: bring windows to forefont                
                MessageBox.Show("activated");
                
            }
        }
    }
