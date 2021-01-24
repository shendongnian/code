        <ListView ItemsSource="{Binding toBinding}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="50" />
                                <ColumnDefinition />
                            </Grid.ColumnDefinitions>
                            <TextBlock Text="Id:" />
                            <TextBlock Grid.Row="1" Text="Name:" />
                            <Label Grid.Column="1" Text="{Binding Id}" />
                            <Label Grid.Row="1" Grid.Column="1" Text="{Binding Name}" />
                        </Grid>
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
