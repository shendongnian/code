    class Program
    {
        static List<string> Colleagues = new List<string>() { "Rob", "Peter"};
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("Data");
            doc.AppendChild(rootNode);
            for (int i = 0; i < 2; i++)
            {
                XmlNode blockNode = doc.CreateElement("Block");
                XmlNode idNode = doc.CreateElement("ID");
                idNode.InnerText = i.ToString();
                blockNode.AppendChild(idNode);
                XmlNode nameNode = doc.CreateElement("Name");
                nameNode.InnerText = Colleagues[i];
                blockNode.AppendChild(nameNode);
                rootNode.AppendChild(blockNode);
            }
            doc.Save("XmlDocument.xml");
        }
    }
