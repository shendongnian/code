    private void NavMenuList_ItemInvoked(object sender, ListViewItem e)
    {
        //NavMenuList.SelectedIndex = -1;
        var item = (NavMenuItem)((NavMenuListView)sender).ItemFromContainer(e);
        if (item != null)
        {
            //AppFrame.Navigate(typeof(RootPages), item.Arguments);
            if (item.DestPage != null &&
                item.DestPage != this.AppFrame.CurrentSourcePageType)
            {
                this.AppFrame.Navigate(item.DestPage, item.Arguments);
            }
        }
    }
