    private void ListView_ItemClick(object sender, ItemClickEventArgs e)
    {            
        var menuItem = e.ClickedItem as MenuItem;
        this.Frame.Navigate(
            menuItem.TargetPage,
            menuItem.DisplayText,
            new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());
    }
