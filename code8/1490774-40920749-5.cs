    public partial class MainWindow : Window
    {
        private List<string> SavedTextBoxTexts = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            
            // Disable button right from the beginning.
            SaveButton.IsEnabled = false;
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            // The function may be called, while the window has not been created completely.
            // So we have to check, if the button can already be referenced.
            if (SaveButton != null)
            {
                // Check if textBox1 is empty or
                // textBox1.text is already in the list of saved strings.
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    SavedTextBoxTexts.IndexOf(textBox1.Text) >= 0)
                {
                    // Disable Button
                    SaveButton.IsEnabled = false;
                    if (WpfHelpers.Confirmation(resources.QuitWithoutSaving, resources.Changes))
                    {
                    }
                }
                else
                {
                    // If textBox1.text has not been saved already
                    // or is an empty string or a string of whitespaces,
                    // enable the SaveButton (again).
                    SaveButton.IsEnabled = true;
                }
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Store the text in textBox1 into the SavedTextBoxTexts list.
            SavedTextBoxTexts.Add(textBox1.Text);
            // Disable the SaveButton.
            SaveButton.IsEnabled = false;
        }
    }
