    // ...snip...
    lb.SelectionMode = SelectionMode.Extended;
    lb.BorderThickness = new Thickness(0);
    lb.Height = 60;
    TreeViewItem lv = new TreeViewItem();
    lv.Header = "TEST";
    lv.Items.Add(lb);
    treeView.Height = 100;
    treeView.Items.Add(lv);
