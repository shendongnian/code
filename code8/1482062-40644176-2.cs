            string xml = @"<Root><Node1>node1 value</Node1><Node2>node2 value</Node2></Root>";
            XDocument doc = XDocument.Parse(xml);
            var root = doc.Root;
            if(root.Name == "Root")
            {
                foreach(var el in root.Descendants())
                {
                   string nodeValue = el.Value;
                }
            }
