    <DataGrid
        Tag="{Binding RelativeSource={RelativeSource AncestorType={x:Type MyView}}}">
        <DataGrid.ContextMenu>
            <ContextMenu>
                <MenuItem Command="{Binding CommandTest}"
                  CommandParameter="{Binding PlacementTarget.Tag.ParentUserControl, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type local:ContextMenu}}}" />
            </ContextMenu>
        </DataGrid.ContextMenu>
    </DataGrid>
