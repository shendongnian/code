    void PopulateTreeViewFromJson(TreeView treeView, string json)
    {
        RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
        var dict = root.data.ToDictionary(n => n.id, 
            n => new TreeNode(n.name.Trim()) { Name = n.id });
        foreach (var item in root.data)
        {
            TreeNode parentNode;
            if (dict.TryGetValue(item.parent, out parentNode))
            {
                parentNode.Nodes.Add(dict[item.id]);
            }
            else
            {
                treeView.Nodes.Add(dict[item.id]);
            }
        }
    }
