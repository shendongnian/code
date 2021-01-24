    var xDoc1 = XDocument.Load(/* xml path */);
    var nodes = xDoc1.Elements("Parent").Elements("Nice");
    if(nodes != null && nodes.Any()) 
    {
       foreach (XElement node in nodes)
       {
           orderedList.Add(node.Attribute("to").Value);
           orderedList.Add(node.Attribute("from").Value);
       }
    }
    orderedList.Sort();
    foreach (var a in orderedList)
    {
       Console.WriteLine(a);
    }
    Console.ReadLine();
