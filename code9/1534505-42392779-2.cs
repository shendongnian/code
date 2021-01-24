    XmlDocument doc = new XmlDocument();
    doc.LoadXml(altitudeResponse);
    var parents = doc.DocumentElement.ChildNodes.Cast<XmlNode>()
                     .Where(n => n.Name != "CustomerName");
    foreach(var parentNode in parents)
    {
        using (XmlNodeReader xmlReader = new XmlNodeReader(parentNode))
        {
            DataSet ds = new DataSet();
            ds.ReadXml(xmlReader);
            DataTable dt = ds.Tables[0].Copy();
            dt.TableName = parentNode.Name;
            dsAltitude.Tables.Add(dt);
        }
    }
