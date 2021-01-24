    <Menu>
        <Menu.Resources>
            <Style TargetType="MenuItem">
                <Setter Property="Command" Value="{Binding MenuItemCommand}" />
            </Style>
        </Menu.Resources>
        <MenuItem Header="Minor Graph" ItemsSource="{Binding GraphMenuItems}">
            <MenuItem.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding SubItems}">
                    <TextBlock Text="{Binding Header}" />
                </HierarchicalDataTemplate>
            </MenuItem.ItemTemplate>
        </MenuItem>
    </Menu>
