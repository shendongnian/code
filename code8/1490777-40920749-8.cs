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
                if (String.IsNullOrEmpty(textBox1.Text) ||
                    textBox1.Text.Trim().Length == 0 ||
                    SavedTextBoxTexts.IndexOf(textBox1.Text.Trim()) >= 0)
                {
                    // Disable Button
                    SaveButton.IsEnabled = false;
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
            SavedTextBoxTexts.Add(textBox1.Text.Trim());
            // Disable the SaveButton.
            SaveButton.IsEnabled = false;
        }
        // This is executed, when the other button has been clicked.
        // The text in textBox1 will not be saved.
        private void AnotherButton_Click(object sender, RoutedEventArgs e)
        {
            if (WpfHelpers.Confirmation(resources.QuitWithoutSaving, resources.Changes))
            {
                // Move to other page ...
            }
        }
    }
