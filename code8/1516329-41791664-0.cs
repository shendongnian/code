    <DataGrid>
        <DataGrid.CellStyle>
            <Style TargetType="DataGridCell">
                <EventSetter Event="PreviewMouseLeftButtonDown" Handler="dg_PreviewMouseLeftButtonDown" />
            </Style>
        </DataGrid.CellStyle>
    </DataGrid>
----------
    private void dg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DataGridCell cell = sender as DataGridCell;
        TextBlock tb = cell.Content as TextBlock;
        if (tb != null)
        {
            MessageBox.Show(tb.Text);
        }
    }
