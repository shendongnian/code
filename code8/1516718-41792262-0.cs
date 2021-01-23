    <DockPanel Width="120" ToolTip="{Binding HeaderText}"
               Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType=TabControl}}">
        <DockPanel.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Close Tab"
                          Command="{Binding PlacementTarget.Tag.CloseTabCommand, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                          CommandParameter="{Binding ItemId}" />
                ...
