    <MenuItem Header="Replace" Click="MenuItem_Replace_Click" ItemsSource="{Binding ReplaceItemsCollection}">
        <MenuItem.ItemTemplate>
            <DataTemplate>
                <MenuItem Header="{Binding}"/>
            </DataTemplate>
        </MenuItem.ItemTemplate>
    </MenuItem>
    <MenuItem Header="Replace" Click="MenuItem_Replace_Click" ItemsSource="{Binding InsertItemsCollection}">
        <MenuItem.ItemTemplate>
            <DataTemplate>
                <MenuItem Header="{Binding}"/>
            </DataTemplate>
        </MenuItem.ItemTemplate>
    </MenuItem>
