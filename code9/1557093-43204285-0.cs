    private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
        {
            TextBlock txt = sender as TextBlock;
            Panel panel = txt.Parent as Panel;
            if (panel != null)
            {
                txt.Visibility = Visibility.Collapsed;
                int index = panel.Children.IndexOf(txt);
                TextBox descContentBox = new TextBox();
                descContentBox.TextWrapping = TextWrapping.Wrap;
                descContentBox.Text = "test";
                descContentBox.Opacity = .68;
                panel.Children.Insert(index, descContentBox);
            }
        }
    }
