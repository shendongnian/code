    <Style TargetType="DataGridCell">
        <Setter Property="Tag" Value="{Binding RelativeSource={RelativeSource AncestorType=UserControl}}" />
        <Setter Property="ContextMenu">
            <Setter.Value>
                <ContextMenu>
                    <MenuItem Header="Open Details"
                              Command="{Binding PlacementTarget.Tag.DataContext.OpenRowDetailsCommand, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                              CommandParameter="{Binding PlacementTarget.Tag.DataContext.SelectedIndex, RelativeSource={RelativeSource AncestorType=ContextMenu}}"/>
                </ContextMenu>
            </Setter.Value>
        </Setter>
    </Style>
