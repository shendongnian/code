        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource; 
            while ((dep != null) && !(dep is DataGridRow))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
 
            if (dep is DataGridRow)
            {
                DataGridRow row = dep as DataGridRow;
                // do something
            }
        } 
