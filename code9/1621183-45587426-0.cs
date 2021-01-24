    public partial class WelcomePage : Page
    {
        public WelcomePage(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            ShowLoginForm();
        }
        private MainWindow parent;
        private async void ShowLoginForm()
        {
            await Task.Delay(2000);
            this.parent.GoToLoginForm();
        }
    }
