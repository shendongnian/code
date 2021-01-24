    private void ListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var textBlock = e.ClickedItem as TextBlock;
        Debug.WriteLine(textBlock.Text);
    }
