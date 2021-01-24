    <TreeView x:Name="tv" ItemsSource="{Binding Items}" Grid.Row="1">
        <TreeView.ItemContainerStyle>
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="Tag" Value="{Binding RelativeSource={RelativeSource AncestorType=Window}}" />
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu>
                            <MenuItem Header="{Binding PlacementTarget.Tag.DataContext.Header, RelativeSource={RelativeSource AncestorType=ContextMenu}}"/>
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
            </Style>
        </TreeView.ItemContainerStyle>
    </TreeView>
