    void productsDataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        CheckBox checkBox = FindParent<CheckBox>(e.OriginalSource as DependencyObject);
        if (checkBox == null)
        {
            rowIndex = GetCurrentRowIndex(e.GetPosition);
            if (rowIndex < 0)
                return;
            productsDataGrid.SelectedIndex = rowIndex;
            Product selectedEmp = productsDataGrid.Items[rowIndex] as Product;
            if (selectedEmp == null)
                return;
            DragDropEffects dragdropeffects = DragDropEffects.Move;
            if (DragDrop.DoDragDrop(productsDataGrid, selectedEmp, dragdropeffects)
                                != DragDropEffects.None)
            {
                productsDataGrid.SelectedItem = selectedEmp;
            }
        }
    }
    static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(dependencyObject);
        if (parent == null)
            return null;
        var parentT = parent as T;
        return parentT ?? FindParent<T>(parent);
    }
