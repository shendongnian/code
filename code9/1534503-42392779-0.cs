    XmlDocument doc = new XmlDocument();
    doc.LoadXml(altitudeResponse);
    foreach(var parentNode in doc.DocumentElement.ChildNodes.Cast<XmlNode>().Skip(1))
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
