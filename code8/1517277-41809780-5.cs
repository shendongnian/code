        Plan p = new Plan();
        p.elements.Items.Add(new Element { id = 1 });
        p.elements.Items.Add(new Element { id = 2 });
        p.elements.Items.Add(new Element { id = 3 });
        Serializer.serializeToXml(p, @"D:\1.xml");
        var p2 = Serializer.deserializeXml<Plan>(@"D:\1.xml");
        Console.WriteLine(p2.elements.Items.Count);
        Serializer.serializeToXml(p2, @"D:\2.xml");
