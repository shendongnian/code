     <DataGrid ItemsSource="{Binding Items}" x:Name="dataGrid">
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding name}" Header="Nazwa" />
    
                    <DataGridTemplateColumn>
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Button Content="Usuń" CommandParameter="{Binding id}" Command="{Binding DataContext.RemoveCommand, ElementName=dataGrid}" />
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
