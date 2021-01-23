    public partial class MainWindow : Window
    {
        private static string TextBoxDefaultValue = "";
        public MainWindow()
        {
            InitializeComponent();
            TextBoxDefaultValue = textBox1.Text;
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SaveButton != null)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text) ||
                    textBox1.Text == TextBoxDefaultValue)
                {
                    SaveButton.IsEnabled = false;
                    if (WpfHelpers.Confirmation(resources.QuitWithoutSaving, resources.Changes))
                    {
                    }
                }
            }
        }
    }
