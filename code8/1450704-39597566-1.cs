         <Grid>
                <ItemsControl ItemsSource="{Binding People}">
                        <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                        <Grid Margin="0,0,0,5">
                                                <Grid.ColumnDefinitions>
                                                        <ColumnDefinition Width="*" />
                                                        <ColumnDefinition Width="100" />
                                                </Grid.ColumnDefinitions>
                                                <TextBlock Text="{Binding Name}" />
                                                <TextBlock Grid.Column="1" Text="{Binding Age}" />
                                        </Grid>
                                </DataTemplate>
                        </ItemsControl.ItemTemplate>
                </ItemsControl>
        </Grid>
