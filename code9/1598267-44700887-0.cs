    for (int i = 0; i < 10; i++)
    {
        XmlElement objectRec = xmlDocNew.CreateElement("object");
        objectRec.InnerText = i.ToString();
        newRec.AppendChild(objectRec);
    }
