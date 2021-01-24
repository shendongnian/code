    private void CategoryItem_Click(object sender, ItemClickEventArgs e)
    {
        MyImage output = e.ClickedItem as MyImage;
        if (output == null) return; // the clicked item was not of the expected type
        string text = output.ImageText;
        string url = output.ImageUrl;
    }
