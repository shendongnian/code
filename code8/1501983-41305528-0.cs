        <DataGrid
            HorizontalAlignment="Left"
            AutoGenerateColumns="False"
            CanUserAddRows="False"
            ItemsSource="{Binding Path=WorldDataList}"
            SelectedItem="{Binding SelectedWorldData}">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Country">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Grid>
                                <ComboBox
                                    ItemsSource="{Binding RelativeSource={RelativeSource FindAncestor,
                                                                                         AncestorType={x:Type DataGrid}},
                                                  Path=DataContext.Countries}"
                                    SelectedIndex="0"
                                    SelectedItem="={Binding RelativeSource={RelativeSource FindAncestor, 
                                                                                           AncestorType={x:Type DataGrid}},
                                                    Path=SelectedItem.Country}" />
                            </Grid>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
