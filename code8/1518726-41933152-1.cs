    <Grid Grid.IsSharedSizeScope="True">
    <DataGrid AutoGenerateColumns="False"
                CanUserAddRows="False"
                ItemsSource="{Binding AllAssets}"
                CanUserResizeColumns="True">
        <DataGrid.Resources>
            <DataTemplate x:Key="NewKey2">
                <ItemsControl ItemsSource="{Binding months}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Grid ShowGridLines="True">
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition SharedSizeGroup="A" />
                                    <ColumnDefinition SharedSizeGroup="B" />
                                </Grid.ColumnDefinitions>
                                <TextBlock Text="{Binding value}"
                                            Margin="5" />
                                <TextBlock Text="{Binding MonthName}"
                                            Margin="5"
                                            Grid.Column="2" />
                            </Grid>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
            <DataTemplate x:Key="NewKey3">
                <StackPanel>
                    <Label HorizontalAlignment="Center">All Headers</Label>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="A" />
                            <ColumnDefinition SharedSizeGroup="B" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="Value"
                                    Margin="5" />
                        <TextBlock Text="Month"
                                    Margin="5"
                                    Grid.Column="1" />
                    </Grid>
                </StackPanel>
            </DataTemplate>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Id">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Label Content="{Binding id}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="Name"
                                    Width="Auto">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Label Content="{Binding name}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn CellTemplate="{StaticResource NewKey2}"
                                    HeaderTemplate="{StaticResource NewKey3}" />
        </DataGrid.Columns>
    </DataGrid>
