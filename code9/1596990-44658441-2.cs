    var L1 = new List<int> {1, 2, 3, 4, 5};
    var L2 = new List<int> {1, 2, 0, 4, 5};
    var dt = new DataTable
                {
                    Columns =
                    {
                        {"Previous", typeof (int)},
                        {"Current", typeof (int)},
                        {"IsDifferent", typeof (bool)},
                    }
                };
    for (int x = 0; x < L1.Count; x++)
        dt.Rows.Add(L1[x], L2[x], L1[x] != L2[x]);
                        
    DgResults.ItemsSource = dt.DefaultView;
<!---->
    <DataGrid Name="DgResults" AutoGenerateColumns="False" ColumnWidth="*" IsReadOnly="True">
        <DataGrid.RowStyle>
            <Style TargetType="DataGridRow">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path=IsDifferent}" Value="true">
                        <Setter Property="Background" Value="Crimson"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.RowStyle>
            
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Path=Previous}"/>
            <DataGridTextColumn Binding="{Binding Path=Current}"/>
        </DataGrid.Columns>
    </DataGrid>
