    private void UnpackOpened(object sender, EventArgs e)
    {
        var currentDoc = Documents.SingleOrDefault(x => x.DocName == dte.ActiveDocument.FullName);
        if (currentDoc == null) return;
        currentDoc.IsRefreshing = true;
        for (var index = 0; index < currentDoc.ExpandedNodes.Count; index++)
        {
            var node = currentDoc.ExpandedNodes[index];
            var pathStrings = node.Split('/').ToList();
            pathStrings.RemoveAll(string.IsNullOrEmpty);
            for (int i = 0; i < pathStrings.Count; i++)
            {
                pathStrings[i] = pathStrings[i].Replace("{", "").Replace("}", "");
                pathStrings[i] = pathStrings[i].Replace("[", "|").Replace("]", "");
            }
            ExpandTree(OutlineWindowInstance.TreeItems.ItemContainerGenerator, pathStrings, 0,
                OutlineWindowInstance.TreeItems);
        }
        currentDoc.IsRefreshing = false;
    }
    void ExpandTree(ItemContainerGenerator itemses, List<string> treeNodes, int step, ItemsControl last)
    {
        while (true)
        {
            last.UpdateLayout();
            var name = treeNodes[step].Split('|')[0];
            var number = int.Parse(treeNodes[step].Split('|')[1]) - 1;
            var selected = itemses.Items.Cast<XmlElement>().Where(x => x.LocalName == name).ToList()[number];
            var selectedItem = ((TreeViewItem) itemses.ContainerFromItem(selected));
            if (selectedItem == null) return;
            selectedItem.IsExpanded = true;
            step++;
            if (treeNodes.Count > step)
            {
                itemses = selectedItem.ItemContainerGenerator;
                last = selectedItem;
                continue;
            }
            break;
        }
    }
