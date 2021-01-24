    var groups = Connection.Groups();
    var navitems = new TileNavItem[groups.Count];
    for (int i=0; i < groups.Count; i++)
    {
        navitems[i] = new TileNavItem
        {
            Caption = groups[i].Description,
            TileText = "Dashboards
        };
    }
