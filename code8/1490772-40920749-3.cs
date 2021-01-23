    public partial class MainWindow : Window
    {
        private static string SavedTextBoxText = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SaveButton != null)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    textBox1.Text == SavedTextBoxText)
                {
                    SaveButton.IsEnabled = false;
                    if (WpfHelpers.Confirmation(resources.QuitWithoutSaving, resources.Changes))
                    {
                    }
                }
                else
                {
                    SaveButton.IsEnabled = true;
                }
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SavedTextBoxText = textBox1.Text;
            SaveButton.IsEnabled = false;
        }
