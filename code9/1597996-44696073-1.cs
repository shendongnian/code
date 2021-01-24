    int index = 0;
    private void dgrData_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (index++ % 2 != 0)
        {
            e.Column.CellStyle = dgrData.Resources["oddCellStyle"] as Style;
        }
    }
----------
    <DataGrid Name="dgrData" ItemsSource="{Binding MyDataTable}"  AutoGeneratingColumn="dgrData_AutoGeneratingColumn" />
        <DataGrid.Resources>
            <Style x:Key="oddCellStyle" TargetType="{x:Type DataGridCell}">
                <Setter Property="Background" Value="Silver"/>
            </Style>
        </DataGrid.Resources>
    </DataGrid>
