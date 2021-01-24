    private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
    {
    }
    private void MyListView_ItemClick(object sender, ItemClickEventArgs e)
    {
    }
    private void TextBlock_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        MyListView.IsItemClickEnabled = false;
    }
    private void TextBlock_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        MyListView.IsItemClickEnabled = true;
    }
