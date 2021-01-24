    <DockPanel HorizontalAlignment="Stretch" Background="Transparent"
               Tag="{Binding RelativeSource={RelativeSource AncestorType=UserControl}}">
        <DockPanel.ContextMenu>
            <ContextMenu>
                <MenuItem 
                    Header="Edit"
                    Command="{Binding Path=PlacementTarget.Tag.DataContext.EditCommand, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                    CommandParameter="{Binding}">
                    <MenuItem.Icon>
                        <Image Source="../Images/edit.png" />
                    </MenuItem.Icon>
                </MenuItem>
            </ContextMenu>
        </DockPanel.ContextMenu>
        ...
    </DockPanel>
