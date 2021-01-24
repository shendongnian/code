    <Button Command="{Binding DataContext.ConnectionSelectCommand, RelativeSource={RelativeSource AncestorType=ItemsControl}}"
            CommandParameter="{Binding}"
            FocusManager.FocusedElement="{Binding ElementName=InstanceName}"
            Style="{DynamicResource DashboardButton}"
            Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType=ItemsControl}}">
        <TextBlock TextWrapping="Wrap" HorizontalAlignment="Center" Text="{Binding Name}" />
        <Button.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Delete"
                        Command="{Binding PlacementTarget.Tag.ConnectionRemoveCommand, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                        CommandParameter="{Binding}" />
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
