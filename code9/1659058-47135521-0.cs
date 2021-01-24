    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        OrderItemValidationRule rule = new OrderItemValidationRule();
        foreach (object item in orderItemDataGrid.Items)
        {
            DataGridRow dgr = orderItemDataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
            if (dgr != null)
            {
                ValidationResult res = rule.Validate(dgr.BindingGroup, null);
                if (!res.IsValid)
                {
                    MessageBox.Show("Cannot save, there are errors in the ORDER ITEMS.", "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    dgr.BringIntoView();
                }
            }
        }
    }
