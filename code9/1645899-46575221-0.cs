    public static TreeElement GenerateTreeStructure(List<TreeElement> baseList)
    {
        TreeElement root = null;
        if (baseList == null || baseList.Count == 0) return root;
        int baseIdx = -1;
        TreeElement prevNode = null;
        TreeElement parent = null;
        while (baseIdx < baseList.Count - 1)
        {
            baseIdx++;
            TreeElement item = baseList[baseIdx];
            if (item.depth == -1)
            {
                root = new TreeElement("root", -1, null);
                prevNode = root;
                continue;
            }
            if (item.depth == prevNode.depth) parent = prevNode.parent; // same level as prevNode
            else if (item.depth > prevNode.depth) parent = prevNode;    // deeper
            else                                                        // shallower
            {
                parent = prevNode.parent;
                while (parent.depth >= item.depth) parent = parent.parent;
            }
            TreeElement newNode = new TreeElement(item.name, item.depth, parent);
            parent.children.Add(newNode);
            prevNode = newNode;
        }
        return root;
    }
    
    // to test
    void Traverse(TreeElement branch, int depth)
    {
        log(new string('\t', depth) + branch.name);
        foreach (var subBranch in branch.children) Traverse(subBranch, depth+1);
    }
    Traverse(root, 0);
