    void Initialize()
    {
        carContextMenu= new ContextMenu();
        MenuItem newQuery = new MenuItem();
        newQuery.Header = "Drive car...";
    
        newQuery.Click += NewQuery_Click;
    
        carContextMenu.Items.Add(newQuery);
    }
    
    void NewQuery_Click(object sender, RoutedEventArgs e)
    {
        MenuItem mi = sender as MenuItem;
        if (mi != null)
        {
            ContextMenu cm = mi.Parent as ContextMenu;
            if (cm != null)
            {
                TreeViewItem node = cm.PlacementTarget as TreeViewItem;
                if (node != null)
                {
                    Console.WriteLine(node.Header);
                }
            }
        }
    }  
