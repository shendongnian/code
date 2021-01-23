    <DataGrid ItemsSource="{Binding Peoples}">
        <DataGrid.ContextMenu>
            <ContextMenu>
                <MenuItem Command="{Binding RemoveCommand}"
                          Header="Remove" />
            </ContextMenu>
        </DataGrid.ContextMenu>
    </DataGrid>
