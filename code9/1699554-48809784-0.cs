    <TreeView ItemsSource="{Binding Items}">
            <TreeView.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding ItemProperty1}"></TextBlock>
                </DataTemplate>
            </TreeView.ItemTemplate>
            <TreeView.ItemContainerStyle>
                <Style TargetType="TreeViewItem">
                    <Setter Property="Local:MouseDoubleClick.Command"
                                    Value="{Binding ElementName=DeviceTreeView, Path=DataContext.TIADeviceTreeItemDoubleClick}"/>
                    <Setter Property="Local:MouseDoubleClick.CommandParameter"
                                    Value="{Binding}"/>
                </Style>
            </TreeView.ItemContainerStyle>
        </TreeView>
