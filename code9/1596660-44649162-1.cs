    <TreeView ScrollViewer.HorizontalScrollBarVisibility="Disabled">
        <TreeView.Resources>
            <HierarchicalDataTemplate DataType="{x:Type local:YourType}" ItemsSource="{Binding Children}">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="{Binding RelativeSource={RelativeSource AncestorType=TreeView}, Path=ActualWidth}"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock TextWrapping="Wrap" Text="{Binding Header}" Foreground="Blue" 
                               Loaded="TextBlock_Loaded" />
                </Grid>
            </HierarchicalDataTemplate>
        </TreeView.Resources>
    </TreeView>
----------
    private void TextBlock_Loaded(object sender, RoutedEventArgs e)
    {
        TextBlock textBlock = sender as TextBlock;
        TreeViewItem tvi = FindParent<TreeViewItem>(textBlock);
        ItemsControl parent = ItemsControl.ItemsControlFromItemContainer(tvi);
        int index = 1;
        while (parent != null && parent.GetType() == typeof(TreeViewItem))
        {
            index++;
            parent = ItemsControl.ItemsControlFromItemContainer(parent);
        }
        textBlock.Margin = new Thickness(0, 0, 25 * index, 0);
    }
