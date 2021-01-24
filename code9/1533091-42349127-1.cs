    <Style TargetType="TreeViewItem">
        <Setter Property="Tag" Value="{Binding RelativeSource={RelativeSource AncestorType=TreeView}}" />
        <Setter Property="ContextMenu">
            <Setter.Value>
                <ContextMenu>
                    <MenuItem Header="Remove"
                                      cal:Action.TargetWithoutContext="{Binding Path=PlacementTarget.Tag.DataContext, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"
                                      cal:Message.Attach="[Event Click] = [Action RemoveResource()]"/>
                </ContextMenu>
            </Setter.Value>
        </Setter>
    </Style>
