    XDocument doc = XDocument.Parse(@"<Root><Node1>node1value</Node1><Node2>node2value</Node2></Root>");
            if(doc!=null)
            {
                if (doc.Root.Name.LocalName == "Root")
                {
                    foreach (var i in doc.Descendants())
                       Console.WriteLine(i.Value);
                }
            }
