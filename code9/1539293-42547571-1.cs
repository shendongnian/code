        private void TextBlock_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            if (tb.ActualHeight >= tb.MaxHeight)
                tb.MaxWidth += 300;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tb.Text += DateTime.Now.ToString();
        }
