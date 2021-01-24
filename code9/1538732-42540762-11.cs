    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void displayDeniedDeletion(string name)
        {
            TextBox errorMessage = new TextBox();
            errorMessage.Text = string.Format("Cannot delete {0} : access denied !", name);
            Window popupErrorMessage = new Window();
            popupErrorMessage.Content = errorMessage;
            popupErrorMessage.ShowDialog();
        }
    }
