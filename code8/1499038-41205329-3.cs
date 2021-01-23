       private byte GridViewSwitch = 0;
       private void GridViewItem_Click (Object sender, ItemClickEventArgs e)
        {
            if(e!=null)
            {
                var item = (GridViewItem)NameOf_ItemClick.ContainerFromItem(e);
                switch(GridViewSwitch)
                case 0 : item.Background = new SolidColorBrush(Windows.UI.Colors.Red); GridViewSwitch++;  break ;
               case 1 : item.Background = new SolidColorBrush(Windows.UI.Colors.Blue); GridViewSwitch++;   break ;
                case 2: item.Background = new SolidColorBrush(Windows.UI.Colors.Green); GridViewSwitch=0;   break ;
            }
        }
