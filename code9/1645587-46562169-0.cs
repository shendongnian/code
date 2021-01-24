    public static void ExportUsingRefection(this DataGrid grid)
    {
        if (grid.ItemsSource == null || grid.Items.Count.Equals(0))
            throw new InvalidOperationException("You cannot export any data from an empty DataGrid.");
        IEnumerable<DataGridColumn> columns = grid.Columns.OrderBy(c => c.DisplayIndex);
        ICollectionView collectionView = CollectionViewSource.GetDefaultView(grid.ItemsSource);
        foreach (object o in collectionView)
        {
            if (o.Equals(CollectionView.NewItemPlaceholder))
                continue;
            foreach (DataGridColumn column in columns)
            {
                if (column is DataGridBoundColumn)
                {
                    string propertyValue = string.Empty;
                    /* Get the property name from the column's binding */
                    BindingBase bb = (column as DataGridBoundColumn).Binding;
                    if (bb != null)
                    {
                        Binding binding = bb as Binding;
                        if (binding != null)
                        {
                            string boundProperty = binding.Path.Path;
                            /* Get the property value using reflection */
                            PropertyInfo pi = o.GetType().GetProperty(boundProperty);
                            if (pi != null)
                            {
                                object value = pi.GetValue(o);
                                if (value != null)
                                    propertyValue = value.ToString();
                            }
                        }
                    }
                    //...
                }
            }
        }
    }
