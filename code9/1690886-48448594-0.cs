    public static string Show(IList<ListItem> items, string title)
    {
        ItemsPopupWindow instance = new ItemsPopupWindow(items, title);
        instance.ShowDialog();
        if (instance.selectedItem == null)
        {
            throw new Exception("The selected item is null.");
        }
        return instance.SelectedItem;
    } 
