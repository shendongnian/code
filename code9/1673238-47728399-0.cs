            var xdoc = XDocument.Load("data.xml");
            var nodes = xdoc.Descendants("subjectvalue");
            foreach (var node in nodes)
            {
                int nodeValue;
                if (int.TryParse(node.Value, out nodeValue))
                {
                    node.Value = (nodeValue + 1).ToString();
                }
            }
            xdoc.Save("data.xml");
