    <DataGrid.Columns>
        <DataGridTextColumn Header="GroupName" Binding="{Binding Path=GroupName}" />
        <DataGridTextColumn Header="DisplayName" Binding="{Binding Path=CLGroup[0].DisplayName}" />
        <DataGridTemplateColumn Header="DisplayName">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <ItemsControl ItemsSource="{Binding Path=CLGroup}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Path=DisplayName}"/>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
                
    </DataGrid.Columns>
