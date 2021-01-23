    private void ContentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.AddedItems.FirstOrDefault() as ListViewItem; //single selection mode
        var type = Type.GetType("UWPControlsIssues4." + item.Tag.ToString()); //my project namespace is "UWPControlsIssues4"
        frame.Navigate(type);
    }
     
