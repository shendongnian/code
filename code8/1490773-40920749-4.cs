    public partial class MainWindow : Window
    {
        private List<string> SavedTextBoxTexts = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            SaveButton.IsEnabled = false;
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SaveButton != null)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    SavedTextBoxTexts.IndexOf(textBox1.Text) >= 0)
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
            SavedTextBoxTexts.Add(textBox1.Text);
            SaveButton.IsEnabled = false;
        }
    }
