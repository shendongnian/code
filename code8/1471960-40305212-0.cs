    internal static class Program
    {
        private static void Main()
        {
            var doc = new XmlDocument();
            doc.LoadXml("<ElementX><A>1</A><B>2</B>Some value</ElementX>");
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15}","Name","Children","ChildElements","Value");
            foreach (XmlElement e in doc.GetElementsByTagName("ElementX"))
                ChildNodeCheck(e);
        }
        private static void ChildNodeCheck(XmlNode element)
        {
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", 
                element.Name, 
                element.HasChildNodes, 
                element.ChildNodes.OfType<XmlElement>().Any(), 
                element.Value);
            if (!element.HasChildNodes) return;
            foreach(XmlNode child in element.ChildNodes)
                ChildNodeCheck(child);
        }
    }
