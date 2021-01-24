     static void Main(string[] args)
     {
            string filePath = "D:\\teste.xml";
            string fullPath = "1$2$3";
            List<string> nodesToBeAdded = fullPath.Split('$').ToList();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            for (int item = 1; item <= 3; item++)
            {
                XmlNode nodeContent = xmlDocument.CreateNode(XmlNodeType.Element, "Content", null);
                XmlNode nodeUID = xmlDocument.CreateNode(XmlNodeType.Element, "UId", null);
                nodeUID.InnerText = item.ToString();//value.UId;
                XmlNode nodeFileName = xmlDocument.CreateNode(XmlNodeType.Element, "FileName", null);
                nodeFileName.InnerText = item + "-Calculator.txt";// value.FileName;
                XmlNode nodeImage = xmlDocument.CreateNode(XmlNodeType.Element, "Image", null);
                nodeImage.InnerText = item + "-Image.jpg";//value.Image;
                for (int i = 0; i < nodesToBeAdded.Count; i++)
                {
                    XmlNode nodeFullPath = xmlDocument.CreateNode(XmlNodeType.Element, "FullPath", null);
                    nodeFullPath.InnerText = nodesToBeAdded[i];
                    if (nodeContent.SelectNodes(string.Concat("//", "Content", '/', "FullPath", "[text()='" + nodesToBeAdded[i] + "']")).Count == 0)
                    {
                        nodeContent.AppendChild(nodeUID);
                        nodeContent.AppendChild(nodeFileName);
                        nodeContent.AppendChild(nodeImage);
                        nodeContent.AppendChild(nodeFullPath);
                    }
                }//add parent node to document
                xmlDocument.DocumentElement.AppendChild(nodeContent);
            }
            xmlDocument.Save("D:\\teste.xml");
        }
