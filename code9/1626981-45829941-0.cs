    for (int i = 0; i < TagList.Count; i++)
    {
        XmlNode NodeToAdd = xmlDoc.CreateElement("Node");
        NodeToAdd.InnerText = "Node Inner Text";
        TagList[i].InsertAfter(NodeToAdd, NameList[i]);
    }
    xmlDoc.Save("output.xml");
