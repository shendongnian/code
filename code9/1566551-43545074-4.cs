    <Style TargetType="{x:Type GroupItem}">
        <Setter Property="Tag" Value="{Binding Path=., RelativeSource={RelativeSource AncestorType=DataGrid}}" />
        <Setter Property="ContextMenu">
            <Setter.Value>
                <ContextMenu>
                    <MenuItem Header="Insert" InputGestureText="Ctrl+I"
                              Command="{Binding PlacementTarget.Tag.DataContext.InsertSelectedItems, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                              CommandParameter="{Binding PlacementTarget.Tag.SelectedIndex, RelativeSource={RelativeSource AncestorType=ContextMenu}}"/>
                    <MenuItem Header="Remove" InputGestureText="Ctrl+D"
                              Command="{Binding PlacementTarget.Tag.DataContext.RemoveSelectedItems, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                              CommandParameter="{Binding PlacementTarget.Tag.SelectedItems, RelativeSource={RelativeSource AncestorType=ContextMenu}}"/>
                </ContextMenu>
            </Setter.Value>
        </Setter>
