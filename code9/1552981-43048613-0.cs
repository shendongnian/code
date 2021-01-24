    <TreeView x:Name="treeView">
        <TreeView.Resources>
            <Style TargetType="TreeViewItem">
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
                <EventSetter Event="PreviewMouseRightButtonDown" Handler="treeView_PreviewMouseRightButtonDown" />
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu>
                            <MenuItem>1</MenuItem>
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
            </Style>
        </TreeView.Resources>
    </TreeView>
----------
    private void treeView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        TreeViewItem tvi = sender as TreeViewItem;
        CharacterViewModel cvm = tvi.DataContext as CharacterViewModel;
        if (cvm != null)
        {
            cvm.IsSelected = true;
        }
        else
        {
            SceneViewModel svm = tvi.DataContext as SceneViewModel;
            if (svm != null)
                svm.IsSelected = true;
        }
    }
