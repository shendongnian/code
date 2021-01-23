    tabc.SelectionChanged += (sender2, args) =>
    {
        if(args.AddedItems != null && args.AddedItems.Count > 0)
        {
            TabItem ti = args.AddedItems[0] as TabItem;
            if(ti != null && VisualTreeHelper.GetChildrenCount(ti) > 0)
            {
                Grid grid = VisualTreeHelper.GetChild(ti, 0) as Grid;
                if (grid != null)
                {
                    Border mainBorder = grid.Children[0] as Border;
                    if (mainBorder != null)
                    {
                        Border innerBorder = mainBorder.Child as Border;
                        if(innerBorder != null)
                            innerBorder.Background = Brushes.Red;
                    }
                }
           }
       }
    };
