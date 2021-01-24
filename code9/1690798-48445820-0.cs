            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(new TextBlock { Text = Utilities.GenerateName(...), Foreground = Brushes.Red });
            stackPanel.Children.Add(new TextBlock { Text = Utilities.GetAttr(...), Foreground = Brushes.Yellow });
            stackPanel.Orientation = Orientation.Horizontal;
            var treeItm = new TreeViewItem {
            Header = stackPanel,
            Tag = firstNode.AbsoluteXPath(),
        };
