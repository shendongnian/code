    List<int> Ids = new List<int>();
    Ids.Add(1);
    
    for (int i = 0; i < Ids.Count; i++)
    {
        ID = Request.QueryString["sID"];
        XmlDocument xmlDoc = new XmlDocument();
        string filepathsUpdate = Server.MapPath("Action.xml");
        xmlDoc.Load(filepathsUpdate);
        XmlNode node = xmlDoc.SelectSingleNode("/CATALOG/CD[ID=" + Ids[i].ToString() + "]/Action");
        node.InnerText = ssplit[0];
        xmlDoc.Save(filepathsUpdate);
    }
