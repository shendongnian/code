    //  Overload for single child TestObject
    public TreeNodeItem RecursiveTreeBuilder(TestObject pList)
    {
        TreeNodeItem node = new TreeNodeItem();
        node.Header = pList.Name;
        foreach (var child in pList.Children)
        {
            if (child != null)
            {
                node.Children.Add(RecursiveTreeBuilder(child));
            }
        }
        return node;
    }
    //  Your list method, with fixes
    public TreeNodeItem RecursiveTreeBuilder(List<TestObject> pList, string rootHeader)
    {
        if (pList == null)
            return null;
        TreeNodeItem rootNode = new TreeNodeItem();
        rootNode.Header = rootHeader;
        foreach (var obj in pList)
        {
            rootNode.Children.Add(RecursiveTreeBuilder(obj));
        }
        return rootNode;
    }
