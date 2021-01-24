    var invokedMenuItem = sender.MenuItems
                                .OfType<NavigationViewItem>()
                                .Where(item => 
                                     item.Content.ToString() == 
                                     args.InvokedItem.ToString())
                                .First();
    var pageTypeName = invokedMenuItem.Tag.ToString();
    var pageType = Assembly.GetExecutingAssembly().GetType($"{PageNamespace}.{pageTypeName}");
    AppFrame.Navigate(pageType);
