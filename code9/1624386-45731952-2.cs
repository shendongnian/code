    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            const int count = 100;
            int searchIndex = 0;
            int.TryParse(textBox.Text, out searchIndex);
            if (searchIndex > count)
            {
                var textChange = e.Changes.First();
                if (textChange != null && textChange.AddedLength > 0)
                {
                    int caret = textBox.CaretIndex;
                    int length = textBox.Text.Length;
                    textBox.TextChanged -= TextBox_TextChanged;
                    textBox.Text = textBox.Text.Substring(0, textChange.Offset) + textBox.Text.Substring(textChange.Offset + textChange.AddedLength);
                    textBox.TextChanged += TextBox_TextChanged;
                    textBox.CaretIndex = caret - Math.Abs(textBox.Text.Length - length);
                }
            }
        }
    }
