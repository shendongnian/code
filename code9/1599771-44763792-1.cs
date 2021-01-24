    <DataGrid.ContextMenu>
        <ContextMenu ItemsSource="{Binding Categories}" Padding="0">
            <ContextMenu.ItemContainerStyle>
                <Style TargetType="MenuItem">
                    <Setter Property="Header" Value="{Binding Name}" />
                    <Setter Property="Tag" Value="{Binding Id}" />
                    <Setter Property="Background" Value="{Binding Brush}" />
                    <EventSetter Event="Click" Handler="MenuItem_Click" />
                </Style>
            </ContextMenu.ItemContainerStyle>
        </ContextMenu>
    </DataGrid.ContextMenu>
