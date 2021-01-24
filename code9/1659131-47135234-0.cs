    <Label Content="{Binding PNR}" Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType=ListView}}">
        <Label.ContextMenu>
            <ContextMenu>
                <MenuItem
                    Name="MenuItemPnr"
                    Header="Copy"
                    Command="{Binding Path=PlacementTarget.Tag.CopyTextCommand, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                    CommandParameter="test"  />
            </ContextMenu>
        </Label.ContextMenu>
    </Label>
