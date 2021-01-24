     <DataGrid CanUserAddRows="True" RowHeight="23" AutoGenerateColumns="False" ItemsSource="{Binding MainClassList}">
                    <DataGrid.Columns>
                        <DataGridTextColumn Width="70*" Header="Column1" Binding="{Binding Row,Mode=OneWay}"></DataGridTextColumn>
                        <DataGridTextColumn Width="70*" Header="Column2" Binding="{Binding RowValue,Mode=OneWay}"></DataGridTextColumn>
                    </DataGrid.Columns>
     </DataGrid>
