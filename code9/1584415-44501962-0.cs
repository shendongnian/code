    XmlDocument newXMLDoc = new XmlDocument();
    newXMLDoc.LoadXml(@"<border><edge thickness=""1.3mm""><color value=""0, 0, 255""/></edge></border>");
    if (Rs.Rows.Count > 0)
     {
        foreach (DataRow query in Rs.Rows)
         {
            if(isRET)
              {
                if (oXFA.DomDocument.SelectSingleNode("//t:*[@name='" + Rs[0] + "']", oNameSpace) != null)
                 {
                    XmlNode newNode = 
    oXFA.DomDocument.ImportNode(newXMLDoc.SelectSingleNode("border"), true);
    oXFA.DomDocument.SelectSingleNode("//t:*[@name='" + Rs[0] + "']", oNameSpace).AppendChild(newNode);
                 }
              }
         }
     }
