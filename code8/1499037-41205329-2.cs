       private bool GridViewSwitch = false;
       private void GridViewItem_Click (Object sender, ItemClickEventArgs e)
        {
            if(e!=null)
            {
                var item = (GridViewItem)NameOf_ItemClick.ContainerFromItem(e);
                if(GridViewSwitch)
                { item.Background = new SolidColorBrush(Windows.UI.Colors.Red); GridViewSwitch = false; }
                else { item.Background = new SolidColorBrush(Windows.UI.Colors.Blue); GridViewSwitch = true;  }
            }
        }
