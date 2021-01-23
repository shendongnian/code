       private void GridViewItem_Click (Object sender, ItemClickEventArgs e)
        {
            if(sender!=null && sender is GridViewItem)
            {
                var item = (GridViewItem)sender;
                if(item.Background == new SolidColorBrush(Windows.UI.Colors.Blue)
                { item.Background = new SolidColorBrush(Windows.UI.Colors.Red); }
                else { item.Background = new SolidColorBrush(Windows.UI.Colors.Blue); }
            }
        }
