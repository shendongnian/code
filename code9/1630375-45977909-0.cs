    <TreeView ItemsSource="{Binding ElementName=ItemHierarchyControl, Path=Items}">
        <TreeView.Resources>
            <local:StringToIcon x:Key="MenuIcon" x:Shared="False" IconName="{Binding IconName}" />
            <HierarchicalDataTemplate DataType="{x:Type local:HierarchyItem}" ItemsSource="{Binding Subitems}">
                <StackPanel Orientation="Horizontal" Margin="0,1,4,1">
                    <TextBlock Text="My text" VerticalAlignment="Center" />
                    <StackPanel.ContextMenu>
                        <ContextMenu ItemsSource="{Binding MenuItems}">
                            <ContextMenu.Resources>
                                <Style TargetType="MenuItem">
                                    <Setter Property="Header" Value="{Binding Path=Name}" />
                                    <Setter Property="Icon" Value="{StaticResource MenuIcon}" />
                                </Style>
                            </ContextMenu.Resources>
                        </ContextMenu>
                    </StackPanel.ContextMenu>
                </StackPanel>
            </HierarchicalDataTemplate>
        </TreeView.Resources>
    </TreeView>
