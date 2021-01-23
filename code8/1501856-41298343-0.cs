    private void PopulateTreeList(TreeList treeList, IEnumerable<string> paths, char pathSeparator)
    {
        foreach (string path in paths)
        {
            TreeListNode parentNode = null;
            foreach (string folder in path.Split(pathSeparator))
            {
                var nodes = parentNode?.Nodes ?? treeList.Nodes;
                var node = nodes.FirstOrDefault(item => item[0].Equals(folder));
                if (node == null)
                    node = treeList.AppendNode(new object[] { folder }, parentNode);
                parentNode = node;
            }
        }
    }
