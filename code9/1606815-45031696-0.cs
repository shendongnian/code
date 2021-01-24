    <ContextMenu ItemsSource="{Binding Path=PlacementTarget.Tag.Actions, RelativeSource={RelativeSource Self}}">
        <ContextMenu.ItemTemplate>
            <HierarchicalDataTemplate DataType="{x:Type local:ContextMenuAction}" ItemsSource="{Binding SubActions}">
                <TextBlock Text="{Binding Header}" />
            </HierarchicalDataTemplate>
        </ContextMenu.ItemTemplate>
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="Command" Value="{Binding Action}"/>
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
