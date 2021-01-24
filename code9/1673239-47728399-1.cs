            var xdoc = XDocument.Load("data.xml");
            var keystageNode = xdoc.Descendants("Keystage3").FirstOrDefault();
            var iterateNode = keystageNode.FirstNode;
            while (iterateNode != null)
            {
                var node = (XElement)iterateNode.NextNode;
                textBox1.Text += node.Element("subjectName").Value;
                textBox2.Text += node.Element("subjectId").Value;
                textBox3.Text += node.Element("subjectvalue").Value;
                iterateNode = iterateNode.NextNode;
            }
