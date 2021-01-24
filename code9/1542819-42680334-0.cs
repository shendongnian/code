    MenuItem lastSelected;
    void navigationItem_selected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
    {
        // If another item is already selected
        if(lastSelected != null) {
            lastSelected.SetChecked(false);
        }
        // Save the handle to the new item and select it
        lastSelected = _navigationView.Menu.FindItem(e.MenuItem.ItemId);
        lastSelected.SetChecked(true);
        initFragmentByMenuId(e.MenuItem.ItemId);
        _drawer.CloseDrawers();
    }
