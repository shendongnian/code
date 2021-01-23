    var nodeQueue = new Queue<Node>();
    nodeQueue.Add(Tree.Root);
    while (!nodeQueue.Empty())
    {
        var item = nodeQueue.Pop();
        foreach(Node child in item.Children)
        {
            nodeQueue.Add(child);
        }
        db.Add(item.Data);
    }   
