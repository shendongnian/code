    <Menu ItemsSource="{Binding Data.MenuCollection}">
        <Menu.Resources>
            <Style TargetType="MenuItem">
                <Setter Property="Command" Value="{Binding Command}" />
            </Style>
        </Menu.Resources>
        <Menu.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                <TextBlock Text="{Binding Header}" />
            </HierarchicalDataTemplate>
        </Menu.ItemTemplate>
    </Menu>
