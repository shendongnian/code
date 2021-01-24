    <DataGrid.ContextMenu>
        <ContextMenu ItemsSource="{Binding Categories}" Padding="0">
            <ContextMenu.ItemTemplate>
                <DataTemplate>
                    <MenuItem Header="{Binding Name}" Background="{Binding Brush}" Click="MenuItem_Click" Tag="{Binding Id}"
                              BorderThickness="0"/>
                </DataTemplate>
            </ContextMenu.ItemTemplate>
        </ContextMenu>
    </DataGrid.ContextMenu>
