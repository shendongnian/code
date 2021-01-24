    private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;            
            //to access parent of the checkbox
            ListViewItem listViewItem =
            GetVisualAncestor<ListViewItem>((DependencyObject)sender);
            //to access parent of the listViewItem(which is parent of checkbox)
            StackPanel stackPanel =
            GetVisualAncestor<StackPanel>((DependencyObject)listViewItem);
            int childCount = VisualTreeHelper.GetChildrenCount(stackPanel);
            //to access child of stackpanel to access the current voltage 
            var vValue = VisualTreeHelper.GetChild(stackPanel, 0) as Label;
    }
    private static T GetVisualAncestor<T>(DependencyObject o)where T : DependecyObject
    {
        ...
    }
