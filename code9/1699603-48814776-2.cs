     <Grid Background="Transparent">
        <Grid.ContextMenu>
            <ContextMenu>
                <MenuItem ItemsSource="{Binding Path=RootItems}" Header="Menu">
                    <MenuItem.Resources>
                        <HierarchicalDataTemplate DataType="{x:Type root:RootItem}" x:Shared="false" ItemsSource="{Binding subItems}">
                            <HierarchicalDataTemplate.ItemContainerStyle>
                                <Style>
                                    <Setter Property="MenuItem.Header" Value="{Binding name}"/>
                                    <Setter Property="MenuItem.Icon" Value="{Binding icon}"/>
                                </Style>
                            </HierarchicalDataTemplate.ItemContainerStyle>
                        </HierarchicalDataTemplate>
                    </MenuItem.Resources>
                    <MenuItem.ItemContainerStyle>
                        <Style>
                            <Setter Property="MenuItem.Header" Value="{Binding name}"/>
                            <Setter Property="MenuItem.Icon" Value="{Binding icon}"/>
                        </Style>
                    </MenuItem.ItemContainerStyle>
                </MenuItem>
            </ContextMenu>
        </Grid.ContextMenu>
    </Grid>
