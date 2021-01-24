    XDocument xdoc = XDocument.Load("YourXMLFile");
    XmlNodeList elemList = xdoc.GetElementsByTagName("string");
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].InnerText);
            }
