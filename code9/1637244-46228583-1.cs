    private void Item_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        var listBoxItem = sender as ListBoxItem;
        listBoxItem.SetValue(ListBoxItemAttachedProperties.IsMouseDownProperty, true);
    }
    private void Item_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        var listBoxItem = sender as ListBoxItem;
        listBoxItem.SetValue(ListBoxItemAttachedProperties.IsMouseDownProperty, false);
    }
