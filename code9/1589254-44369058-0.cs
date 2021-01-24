    private void chkall_Checked(object sender, RoutedEventArgs e)
    {
        foreach (var r in userDG.Items)
        {
            DataGridRow row = (DataGridRow)userDG.ItemContainerGenerator.ContainerFromItem(r);
            FrameworkElement FW_element = userDG.Columns[0].GetCellContent(row);
            //We use the CellTemplate defined on the column to find the CheckBox
            var checkbox = ((DataGridTemplateColumn)userDG.Columns[0]).CellTemplate.FindName("chksingle", FW_element) as CheckBox;
            checkbox.IsChecked = true;
        }
    }
