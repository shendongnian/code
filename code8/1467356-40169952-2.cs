    var idToFind = "2childnode3.txt";
    var node = nodes.SelectMany(n => n.DescendantsAndSelf())
                    .Where(n => n.Id == idToFind)
                    .FirstOrDefault();
    if (node != null) 
    {
        Console.WriteLine(node.ItsPath);
    }
    else
    {
        Console.WriteLine("Not found");
    }
