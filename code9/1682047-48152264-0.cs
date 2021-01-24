    private void CategoriesItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        // Gets the MainPage
        var page = (MainPage)((Frame)Window.Current.Content).Content;
        page.Categories = new ObservableCollection<NavigationViewItem>();
    
        // Creates all the NavigationViewItems, based on CategoriesItems
        foreach (Category cat in CategoriesItems)
            page.Categories.Add(new NavigationViewItem
            {
                Content = cat.Title,
                Icon = new SymbolIcon((Symbol)Enum.GetValues(typeof(Symbol)).GetValue(cat.IconIndex))
            });
        //Here is the code to set the NavigationView's MenuItemsSource.
        NavigationView nav= (NavigationView)page.FindName("nav");
        nav.MenuItemsSource = page.Categories;
    }
