     private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
            {
                int searchIndex = 0;
                int count = 100;
                int.TryParse(textBox.Text, out searchIndex);
                if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
                {
                    if (searchIndex > count)
                    {
                        textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                        textBox.SelectionStart = textBox.Text.Length;
                        textBox.SelectionLength = 0;
                    }
                }
            }
        }
