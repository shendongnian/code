        public void OnTreeItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem clickedItem = TryGetClickedItem(treeView, e);
            if (clickedItem == null || clickedItem!=sender)
                return;
            //e.Handled = true; // if you want to to cancel expanded/collapsed toggle
            Console.WriteLine(clickedItem.Header);
        }
        TreeViewItem TryGetClickedItem(TreeView treeView, MouseButtonEventArgs e)
        {
            var hit = e.OriginalSource as DependencyObject;
            while (hit != null && !(hit is TreeViewItem))
                hit = VisualTreeHelper.GetParent(hit);
            return hit as TreeViewItem;
        }
