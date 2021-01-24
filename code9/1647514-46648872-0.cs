    <ContextMenu x:Key="ContextMenu"
                 DataContext="{Binding}"
                 ItemsSource="{Binding ContextMenuItems, RelativeSource={RelativeSource AncestorType=UserControl}}">
        <ContextMenu.Resources>
            ...
        </ContextMenu.Resources>
    </ContextMenu>
