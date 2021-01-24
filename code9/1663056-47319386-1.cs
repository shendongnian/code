    void PopulateTreeViewFromJson(TreeView treeView, string json)
    {
        RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
        var dict = root.data.ToDictionary(n => n.id, 
            n => new TreeNode(n.name.Trim()) { Name = n.id });
        foreach (var item in root.data)
        {
            TreeNode node = dict[item.id];
            TreeNode parentNode;
            if (dict.TryGetValue(item.parent, out parentNode))
            {
                parentNode.Nodes.Add(node);
            }
            else
            {
                treeView.Nodes.Add(node);
            }
        }
    }
