            string xml = @"<Root><Node1>node1 value</Node1><Node2>node2 value</Node2></Root>";
            XDocument doc = XDocument.Parse(xml);
            if(doc.Root.Name == "Root")
            {
                foreach(var el in doc.Root.Descendants())
                {
                   string nodeValue = el.Value;
                }
            }
