        <Window.Resources>
            <CollectionViewSource x:Key="CvsKey">
                <CollectionViewSource.GroupDescriptions>
                    <PropertyGroupDescription PropertyName="Country"/>
                </CollectionViewSource.GroupDescriptions>
            </CollectionViewSource>
        </Window.Resources>
    
        <Grid>
            <DataGrid x:Name="dg" Loaded="dg_Loaded" HorizontalScrollBarVisibility="Disabled" HeadersVisibility="All" Grid.Column="0" RowHeaderWidth="0" CanUserAddRows="False" AutoGenerateColumns="False"  VerticalContentAlignment="Center" HorizontalContentAlignment="Center">            
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Country"  Width="75">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>                           
                                <Grid>
                                    <TextBlock VerticalAlignment="Center" Text="{Binding Name}"/>
                                </Grid>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                    <DataGridTemplateColumn Header="Name"  Width="75">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <DataGrid ItemsSource="{Binding Items}" IsReadOnly="True" AutoGenerateColumns="False" HeadersVisibility="None">
                                    <DataGrid.Columns>
                                        <DataGridTemplateColumn Width="*">
                                            <DataGridTemplateColumn.CellTemplate>
                                                <DataTemplate>
                                                    <TextBlock Text="{Binding Name}"/>
                                                </DataTemplate>
                                            </DataGridTemplateColumn.CellTemplate>
                                        </DataGridTemplateColumn>
                                    </DataGrid.Columns>
                                </DataGrid>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
              </DataGrid.Columns>            
            </DataGrid>
        </Grid>
    </Window>
DataGrid.Loaded event
     private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            var groups = (this.Resources["CvsKey"] as CollectionViewSource).View.Groups;
            dg.ItemsSource = groups;
        }
