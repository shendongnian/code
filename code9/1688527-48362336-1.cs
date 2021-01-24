    //get the Type of the currently displayed page
    var pageName = AppFrame.Content.GetType().Name;
    //find menu item that has the matching tag
    var menuItem = AppNavigationView.MenuItems
                             .OfType<NavigationViewItem>()
                             .Where(item => item.Tag.ToString() == pageName)
                             .First();
    //select
    AppNavigationView.SelectedItem = menuItem;
