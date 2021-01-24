    <TreeView ItemsSource="{Binding Source={StaticResource MyXmlProvider}}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding XPath=./*}" />
        </TreeView.ItemTemplate>
        <TreeView.ItemContainerStyle>
            <Style TargetType="TreeViewItem">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path=NodeType}" Value="Element">
                        <Setter Property="Header" Value="{Binding Converter={StaticResource NameGeneration}}"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </TreeView.ItemContainerStyle>
    </TreeView>
