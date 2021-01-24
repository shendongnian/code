    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel model = (ViewModel)DataContext;
            RichTextBox richTextBox = (RichTextBox)sender;
            TextRange range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            var text = range.Text.Trim();
            model.TextLength = text.Length;
            if (text.Length > 140)
            {
                int split = 0;
                while (richTextBox.CaretPosition.DeleteTextInRun(-1) == 0)
                {
                    richTextBox.CaretPosition.GetPositionAtOffset(--split);
                }
            }
        }
    }
