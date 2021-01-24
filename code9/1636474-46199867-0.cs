    using System.Xml.Linq;
    ...
    var lists = new[]
                    {
                        new object[]
                            {
                                new ClassA("0", "1", "2"), new ClassA("1", "4", "2"), new ClassA("2", "4", "3"),
                                new ClassA("3", "5", "2"),
                            },
                        new object[]
                            {
                                new ClassB("0", "1"), new ClassB("1", "4"), new ClassB("2", "4"),
                                new ClassB("3", "5"),
                            }
                    };
    
    var xml = new XDocument(new XElement("Root"));
    for (var i = 0; i < lists.Length; i++)
    {
        var eFrame = new XElement($"frame{i}");
        var list = lists[i];
        foreach (var obj in list)
        {
            var eRec = new XElement("rec");
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                eRec.SetAttributeValue(prop.Name, prop.GetValue(obj).ToString());
            }
            eFrame.Add(eRec);
        }
        xml.Root.Add(eFrame);
    }
