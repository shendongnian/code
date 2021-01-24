        <Grid Grid.Column="2"
          Grid.Row="1">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <DataGrid>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Path=GroupName}"
                                    Header="Group Name" 
                                    Width="*"/>
                <DataGridTemplateColumn Header="Actions"
                                        Width="2"   
                                        ToolTipService.ToolTip="Remove Group"                                            
                                        IsReadOnly="True">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button 
                                    Style="{StaticResource CustXButton}"
                                    Command="Delete" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
