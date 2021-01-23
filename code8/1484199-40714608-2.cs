    private void dataGridOrderItems_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DependencyObject depObj = (DependencyObject)e.OriginalSource;
    
        while (depObj != null && !(depObj is DataGridRow))
        {
            depObj = VisualTreeHelper.GetParent(depObj);
        }
    
        if (depObj != null && depObj is DataGridRow)
        {
            DataGridRow dgRow = (DataGridRow)depObj;
            dgRow.IsSelected = !dgRow.IsSelected;
            e.Handled = true;
        }
    }
