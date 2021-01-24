    GridViewColumnHeader _lastHeaderClicked;
    ListSortDirection _lastDirection = ListSortDirection.Ascending;
    
    private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
    {
        GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
    
        if (headerClicked != null)
        {
            if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
            {
                ListSortDirection direction;
                if (!ReferenceEquals(headerClicked, _lastHeaderClicked))
                {
                    direction = ListSortDirection.Ascending;
                }
                else
                {
                    if (_lastDirection == ListSortDirection.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                }
    
                string bindingName = headerClicked.Column.GetValue(GridViewColumnAttachedProperties.SortPropertyNameProperty) as string;
                Sort(bindingName, direction);
    
                if (direction == ListSortDirection.Ascending)
                {
                    headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowUp"] as DataTemplate;
                }
                else
                {
                    headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowDown"] as DataTemplate;
                }
    
                // Remove arrow from previously sorted header  
                if (_lastHeaderClicked != null && !ReferenceEquals(_lastHeaderClicked, headerClicked))
                {
                    _lastHeaderClicked.Column.HeaderTemplate = null;
                }
    
                _lastHeaderClicked = headerClicked;
                _lastDirection = direction;
            }
        }
    }
    private void Sort(string sortBy, ListSortDirection direction)
    {
        ICollectionView dataView = CollectionViewSource.GetDefaultView(lv.ItemsSource);
    
        dataView.SortDescriptions.Clear();
        SortDescription sd = new SortDescription(sortBy, direction);
        dataView.SortDescriptions.Add(sd);
        dataView.Refresh();
    }
