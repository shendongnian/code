    private static void RemoveNode(string sID)
        {
            XDocument doc = XDocument.Load(@"D:\\Projects\\RemoveNode.xml");
            var v = from n in doc.Descendants("Customer")
                         where n.Element("id").Value == sID
                         select n;
            v.Remove();
            doc.Save(@"D:\\Projects\\RemoveNode.xml");
        }
