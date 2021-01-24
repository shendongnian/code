    <Grid>
        <DataGrid x:Name="dG" ItemsSource="{Binding DGCollections}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Foreground="Black" Text="{Binding ID}"></TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Width="*">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Grid HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="Auto"></ColumnDefinition>
                                    <ColumnDefinition Width="Auto"></ColumnDefinition>
                                    <ColumnDefinition Width="Auto"></ColumnDefinition>
                                </Grid.ColumnDefinitions>
                                <TextBlock Foreground="Black" Text="{Binding Key}" Grid.Column="0"></TextBlock>
                                <TextBlock Foreground="Gray" Text=" : " Grid.Column="1"></TextBlock>
                                <TextBlock Foreground="Red" Text="{Binding Value}" Grid.Column="2"></TextBlock>
                            </Grid>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
