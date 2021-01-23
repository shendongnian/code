    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string s = ConvertRichTextBoxContentsToString(rtb);
            if (string.IsNullOrWhiteSpace(s))
            {
                MessageBox.Show("empty!");
            }
        }
    }
----------
    <RichTextBox x:Name="rtb" />
