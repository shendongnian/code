    <DataGrid x:Name="dgrid">
        <DataGrid.Columns>
            <DataGridTemplateColumn>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Grid>
                            <TextBlock>...</TextBlock>
                            <Button x:Name="btn" Content="Add" Visibility="Collapsed" />
                        </Grid>
                        <DataTemplate.Triggers>
                            <DataTrigger Binding="{Binding Path=DataContext, RelativeSource={RelativeSource AncestorType=DataGridRow}}"
                                                 Value="{x:Static CollectionView.NewItemPlaceholder}">
                                <Setter TargetName="btn" Property="Visibility" Value="Visible" />
                            </DataTrigger>
                        </DataTemplate.Triggers>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
