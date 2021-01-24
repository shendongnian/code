    <TreeView Name="treeContainer">
                <TreeViewItem Header="Tables" Name="treeTablesContainer">
                    <ItemsControl.ItemContainerStyle>
                        <Style TargetType="{x:Type TreeViewItem}" />
                    </ItemsControl.ItemContainerStyle>
                    <ItemsControl.ItemTemplate>
                        <HierarchicalDataTemplate>
                            <TextBlock Text="{Binding }" />
                        </HierarchicalDataTemplate>
                    </ItemsControl.ItemTemplate>
                </TreeViewItem>
            </TreeView>
