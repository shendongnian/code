    <UserControl.ContextMenu>
        <ContextMenu>
            <!-- other menu items here -->
            <MenuItem
                Header="Draggable"
                IsCheckable="True"
                IsChecked="{Binding Path=PlacementTarget.IsDraggable, RelativeSource={RelativeSource AncestorType=ContextMenu}}" />
        </ContextMenu>
    </UserControl.ContextMenu>
