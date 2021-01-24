    public ColorizeWordWindow() {
          InitializeComponent();
          this.RichTextBox1.TextChanged += RichTextBox_TextChanged;
    }
    
        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e) {
          RichTextBox1.TextChanged -= RichTextBox_TextChanged;
          int position = RichTextBox1.CaretPosition.
                          GetOffsetToPosition(RichTextBox1.Document.ContentEnd);
    
          foreach (Paragraph para in RichTextBox1.Document.Blocks.ToList())
          {
            string text = new TextRange(para.ContentStart, para.ContentEnd).Text;
    
            para.Inlines.Clear();
    
            // using space as word delimiter assumes en-US for locale
            // other locales (Korean, Thai, etc. ) will need adjustment
    
            var words = text.Split(' ');
            int count = 1;
    
            foreach (string word in words)
            {
              if (word.StartsWith("D"))
              {
                var run = new Run(word);
    
                run.Foreground = new SolidColorBrush(Colors.Red);
                run.FontWeight = FontWeights.Bold;
                para.Inlines.Add(run);
              }
              else
              {
                para.Inlines.Add(word);
              }
    
              if (count++ != words.Length)
              {
                para.Inlines.Add(" ");
              }
            }
          }
    
          RichTextBox1.CaretPosition = RichTextBox1.Document.ContentEnd.
                                         GetPositionAtOffset(-position);
          RichTextBox1.TextChanged += RichTextBox_TextChanged;
        }
