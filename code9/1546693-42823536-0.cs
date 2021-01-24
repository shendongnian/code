    ListView1.SelectedIndex = e.ItemIndex;
    XmlDocument xmldoc = new XmlDocument();
    xmldoc.Load(path);
    
    XmlNodeList nodes = xmldoc.GetElementsByTagName("Details");
    for (int i = 0; i < nodes.Count; i++)
    {
        if (i == e.ItemIndex)
        {
    
            nodes[i].ParentNode.RemoveChild(nodes[i]);
            break;
        }
    }
    xmldoc.Save(path);
    BindDatalist();
