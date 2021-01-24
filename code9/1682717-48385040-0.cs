    TreeViewItem treeItem = new TreeViewItem();
                treeItem.Header = "North America";
    
                treeItem.Items.Add(new TreeViewItem() { Header = "USA" });
                treeItem.Items.Add(new TreeViewItem() { Header = "Canada" });
                treeItem.Items.Add(new TreeViewItem() { Header = "Mexico" });
    
                TreeView treeView = new TreeView();
                treeView.Items.Add(treeItem);
    
    
                sampleStack.Children.Add(treeView);
