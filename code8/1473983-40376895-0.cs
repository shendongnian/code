    <ItemsControl ItemsSource="{Binding}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding Firstname}"
                                Margin="10" />
                    <ComboBox ItemsSource="{Binding Path=AvailableGenders}"
                                SelectedValue="{Binding Path=Gender}"
                                Grid.Column="1" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
