       private void GridViewItem_Click (Object sender, ItemClickEventArgs e)
        {
            if(e!=null)
            {
                var item = (GridViewItem)NameOf_ItemClick.ContainerFromItem(e);
                if((item.Background as SolidColorBrush).Color == Windows.UI.Colors.Blue)
                { item.Background = new SolidColorBrush(Windows.UI.Colors.Red); }
                else { item.Background = new SolidColorBrush(Windows.UI.Colors.Blue); }
            }
        }
