        private string currentText;
        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Back)
            {
                if (string.IsNullOrWhiteSpace(currentText))
                    return;
                ((TextBox)sender).Text = currentText;
                ((TextBox)sender).SelectionStart = currentText.Length;
                ((TextBox)sender).SelectionLength = 0;
            }
        }
        private void TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            currentText = ((TextBox)sender).Text;
        }
