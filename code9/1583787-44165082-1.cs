        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
                TextBlockSearch.Visibility = Visibility.Visible;
            else
                TextBlockSearch.Visibility = Visibility.Collapsed;
        }
