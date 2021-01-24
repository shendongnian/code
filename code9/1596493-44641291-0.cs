    <ListView Name="ListView" ItemsSource="{Binding Items}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding Key}" />
                    <TextBlock Grid.Column="1" Text="{Binding Value}" />
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
