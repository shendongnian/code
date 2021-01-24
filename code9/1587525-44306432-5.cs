    <DataGrid x:Name="dataGrid" Grid.Row="1"  ItemsSource="{Binding ViewList}" 
               CanUserAddRows="False" AlternationCount="2" AlternatingRowBackground="Blue" >
        <DataGrid.Columns>
            <DataGridTextColumn Header="View" Binding="{Binding Id}" Width="2*" IsReadOnly="True" />
            <DataGridTemplateColumn Header="Is Enabled" Width="Auto">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding IsEnabled , Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>                
        </DataGrid.Columns>
    </DataGrid>
