    <TabControl ItemsSource="{Binding Items}" SelectedItem="{Binding SelectedItem}">
        <TabItem>                    <!-- DataContext is SelectedItem -->
            <TreeUserControl>        <!-- DataContext is SelectedItem -->
                <ExtendedTreeView /> <!-- DataContext is SelectedItem -->
            </TreeUserControl>
        </TabItem>
        ...
    </TabControl>
