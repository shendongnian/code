        private void DataGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            // iteratively traverse the visual tree
            while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;
            if (dep is DataGridColumnHeader)
            {
                DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
                // do something
            }
            if (dep is DataGridCell)
            {
                DataGridCell cell = dep as DataGridCell;
                // do something
            }
        }
