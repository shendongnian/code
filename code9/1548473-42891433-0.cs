    private void dg_GotFocus(object sender, RoutedEventArgs e)
    {
        DataGridCell cell = e.OriginalSource as DataGridCell;
        if (cell != null && cell.Column is DataGridCheckBoxColumn)
        {
            dg.BeginEdit();
            CheckBox chkBox = cell.Content as CheckBox;
            if (chkBox != null)
            {
                chkBox.IsChecked = !chkBox.IsChecked;
            }
        }
    }
----------
    <DataGrid x:Name="dg" AutoGenerateColumns="False" GotFocus="dg_GotFocus">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn Binding="{Binding IsChecked, UpdateSourceTrigger=PropertyChanged}" />
            ...
