     <Grid Background="Transparent">
        <Grid.ContextMenu>
            <ContextMenu>
                <MenuItem ItemsSource="{Binding Path=RootItems}" Header="Menu">
                    <MenuItem.Resources>
                        <Image x:Key="ico" Source="C:\Users\user1\source\repos\WpfApp3\WpfApp3\mytestimage.bmp" x:Shared="false"/>
                        <HierarchicalDataTemplate DataType="{x:Type root:RootItem}" x:Shared="false" ItemsSource="{Binding subItems}">
                            <HierarchicalDataTemplate.ItemContainerStyle>
                                <Style>
                                    <Setter Property="MenuItem.Header" Value="{Binding name}"/>
                                    <Setter Property="MenuItem.Icon" Value="{StaticResource ico}"/>
                                </Style>
                            </HierarchicalDataTemplate.ItemContainerStyle>
                        </HierarchicalDataTemplate>
                    </MenuItem.Resources>
                    <MenuItem.ItemContainerStyle>
                        <Style>
                            <Setter Property="MenuItem.Header" Value="{Binding name}"/>
                            <Setter Property="MenuItem.Icon" Value="{StaticResource ico}"/>
                        </Style>
                    </MenuItem.ItemContainerStyle>
                </MenuItem>
            </ContextMenu>
        </Grid.ContextMenu>
    </Grid>
