      private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
                TextBox textBox = sender as TextBox;
                int searchIndex = 0;
                int Count = 100;
                int.TryParse(textBox.Text, out searchIndex);
                if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
                {
                    if (searchIndex > Count)
                    {
                        textBox.Text = OldValue.ToString();
                        textBox.SelectionStart = start;
                     }
                 }
          }
   
    public int OldValue = 0;
    public int start = 0;
     private void SearchTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int.TryParse(textBox.Text, out OldValue);
            start = textBox.SelectionStart;
        }
