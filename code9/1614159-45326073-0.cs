    <Menu ItemsSource="{Binding MenuItems}">
        <Menu.Resources>
            <Style TargetType="MenuItem">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Title}" Value="-">
                        <Setter Property="Template">
                             <Setter.Value>
                                <ControlTemplate>
                                    <Separator/>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Menu.Resources>
        <Menu.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                <TextBlock Text="{Binding Title}" Background="Red" />
            </HierarchicalDataTemplate>
        </Menu.ItemTemplate>
    </Menu>
