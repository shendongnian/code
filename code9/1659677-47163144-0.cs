    xmldoc.Load(xmlfile);
    xmlnode = xmldoc.GetElementsByTagName("item");
    dynamic node= new ExpandoObject();
    var dictionary = (IDictionary<string, object>)node;
        for (int i = 0; i < xmlnode.Count; i++)
        {
    dictionary.Add(xmlnode[i].ChildNodes.Item(0).InnerText, xmlnode[i].ChildNodes.Item(1).InnerText)
    }
    var json = JsonConvert.SerializeObject(dictionary);
