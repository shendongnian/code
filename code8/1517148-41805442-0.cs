    static void DynamicallySetMenuItems(MenuItem menu, UserRole role)
    {
        var menuItems = GetMenuItems(role);
        var previous = menuItems.FirstOrDefault();
        
        if (previous == null)
            return;
        
        if (!IsSeparator(previous))
        {    
            menu.MenuItems.Add(previous);
        }
        
        foreach (var current in menuItems.Skip(1))
        {
            if (!IsSeparator(current) ||
                !IsSeparator(previous))
            {
                menu.MenuItems.Add(previous);
            }
        
            previous = current;
        }        
        
        if (IsSeparator(previous))
        {
            menu.MenuItems.Remove(previous);
        }
    }
    
    static bool IsSeparator(MenuItem menu)
        => menu.Text == "-";
