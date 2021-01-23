    private void cboTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableData == null | (TableData != null && TableData.DataContext == null)) { return; }
            TableData.xDataGrid.ItemsSource = (((DataTable)(TableData.DataContext)).DataSet.Tables[(string)cboTables.SelectedItem]).DefaultView;
        }
