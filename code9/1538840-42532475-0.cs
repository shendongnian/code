            <DataGrid CanUserAddRows="True" RowHeight="23" AutoGenerateColumns="False" ItemsSource="{Binding MainClassList}">
                <DataGrid.Columns>
                    <DataGridTextColumn Width="70*" Header="Column1" Binding="{Binding Column1Value,Mode=OneWay}"></DataGridTextColumn>
                    <DataGridTextColumn Width="70*" Header="Column2" Binding="{Binding Column2Value,Mode=OneWay}"></DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
