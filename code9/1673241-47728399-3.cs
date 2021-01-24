            var xdoc = XDocument.Load("data.xml");
            var keystageNode = xdoc.Descendants("Keystage3").FirstOrDefault();
            var iterateNode = keystageNode.FirstNode;
            var subjectNodes = new List<SubjectNode>();
            while (iterateNode != null)
            {
                var node = (XElement)iterateNode.NextNode;
                subjectNodes.Add(new SubjectNode
                {
                    SubjectName = node.Element("subjectName").Value,
                    SubjectId = node.Element("subjectId").Value,
                    SubjectValue = node.Element("subjectvalue").Value
                });
                iterateNode = iterateNode.NextNode;
            }
