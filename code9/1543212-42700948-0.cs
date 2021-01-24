    private void BorderIndent_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ListViewItem lvItem = UITools.FindAncestor<ListViewItem>(e.OriginalSource as DependencyObject);
        bool isListViewItem = lvItem != null;
        if (isListViewItem)
        {
            lvItem.RaiseEvent(e);
        }
    }
