    private void snoTextBox_GotFocus(object sender, RoutedEventArgs e)
            {
                DependencyObject dep = (DependencyObject)e.OriginalSource;
    
                // iteratively traverse the visual tree
                while ((dep != null) && !(dep is DataGridCell) && !(dep is System.Windows.Controls.Primitives.DataGridColumnHeader))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
    
                if (dep == null)
                    return;
    
                if (dep is DataGridCell)
                {
                    DataGridCell cell = dep as DataGridCell;
                    // navigate further up the tree
                    while ((dep != null) && !(dep is DataGridRow))
                    {
                        dep = VisualTreeHelper.GetParent(dep);
                    }
    
                    DataGridRow row = dep as DataGridRow;
                    if (row != null)
                    {
                        ComponentData cd = row.DataContext as ComponentData;
                        statusMessage(cd.ComponentNumber);
                    }
                }
            }
