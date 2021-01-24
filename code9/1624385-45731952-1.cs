    private void SearchTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            string text = textBox.Text + e.Text;
            if (!string.IsNullOrEmpty(text))
            {
                int searchIndex = 0;
                int count = 100;
                int.TryParse(text, out searchIndex);
                e.Handled = (searchIndex > count);
            }
        }
    }
