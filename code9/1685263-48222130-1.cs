    private static void PrintInDotFormat(Node root)
    {
        // 1. Create graph
        var nodes = new HashSet<Node>();
        var openList = new Queue<Node>();
        var references = new List<KeyValuePair<Node, Node>>();
        openList.Enqueue(root);
        while (openList.Count > 0)
        {
            var current = openList.Dequeue();
            nodes.Add(current);
            foreach (var child in current.ChildNodes)
            {
                references.Add(new KeyValuePair<Node, Node>(current, child));
                if (nodes.Contains(child))
                    continue;
                openList.Enqueue(child);
            }
        }
        // 2. Print it to console
        Console.WriteLine("digraph DecisionTree {");
        foreach (var node in nodes)
            Console.Write($"{node.Name};");
        Console.WriteLine();
        foreach (var pair in references)
            Console.WriteLine($"{pair.Key.Name}->{pair.Value.Name};");
        Console.WriteLine("}");
    }
    
