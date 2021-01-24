    ...
    listView.ItemTapped += (sender, args) =>
    {
        // you don't really need a switch here, as all your pages 
        // are kept in aa MasterPageItem 
        // Its Good to check if its not null
        if (args is MasterPageItem item)
        {
            // set the Detail page when click
            // Activator.CreateInstance, is just a fancy way of saying create the
            // page from the type you supplied earlier 
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            IsPresented = false;
        }
    };
    ...
