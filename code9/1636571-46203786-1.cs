    private void TextBlock_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        Panel root = sender as Panel;
        var dataObject = root.DataContext;
        tb.Text = dataObject.ToString(); //displays the currently pointed number in "tb"
    }
    private void TextBlock_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        tb.Text = string.Empty;
    }
