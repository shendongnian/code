    MasterDetailPage mdp = new MasterDetailPage();
    ContentPage master = new ContentPage { Title = "Menu" };
    StackLayout menu = new StackLayout();
    ListView menuList = new ListView() { RowHeight = 60 };
    menuList.ItemSelected = OnMenuItemSelected;
    ContentPage detail = new ContentPage();
    
    menu.Children.Add(menuList);
    master.Content = menu;
    mdp.Master = master;
    
    mdp.Detail = new NavigationPage(detail);
