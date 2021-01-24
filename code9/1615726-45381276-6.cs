    var bases = new List<Base>();
    using (var xmlReader = XmlReader.Create("test.xml"))
    {
        while (xmlReader.ReadToFollowing("Base"))
        {
            string name = xmlReader.GetAttribute("Name");
            int count = 0;
            using (var innerReader = xmlReader.ReadSubtree())
            {
                while (innerReader.ReadToFollowing("Book"))
                    count++;
            }
            bases.Add(new Base { Name = name, Count = count });
        }
    }
