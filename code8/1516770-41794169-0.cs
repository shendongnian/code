    public static XmlNode CreateNode(XmlDocument document)
        {
            XmlElement trElement = document.CreateElement("Descriptions");
            XmlElement textElement = document.CreateElement("Text");
            textElement.SetAttribute("String", "Abcdef");
            textElement.SetAttribute("Language", "ENG");
            trElement.AppendChild(textElement);
            return trElement;
        }
        public static void doWork(string filePath)
        {
            XmlDocument fromXML;
            fromXML = new XmlDocument();
            fromXML.Load(filePath);
            XmlNode fromRoot = fromXML.DocumentElement;
            // Start from <Student></Student>
            foreach (XmlNode node in fromRoot.ChildNodes)
            {
                InsertNewNodes(node, fromXML);
            }
            fromXML.Save(Console.Out);
        }
        public static void InsertNewNodes(XmlNode root, XmlDocument document)
        {
            var hasDescription = false;
            // Iterate over every first level child looking for "Descriptions"
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "Descriptions")
                {
                    hasDescription = true;
                }
                // recursively call InsertNewNodes
                if (node.ChildNodes.Count > 0)
                {
                    InsertNewNodes(node, document);
                }
            }
            // Adjust the root.LastChild.NodeType criteria to only add the nodes when you want
            // In this case I only add the Description if the subnode has Elements
            if (!hasDescription && root.LastChild.NodeType == XmlNodeType.Element)
            {
                var newNode = CreateNode(document);
                root.PrependChild(newNode);
            }
        }
