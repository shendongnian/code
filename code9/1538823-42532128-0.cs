    var pos = "1; 2; 3";
    var des = "aaa; bbb; ccc";
    var pcs = "1.000; 44.000; 65.000";
    
    var posList = pos.Split(';').ToList();
    var desList = des.Split(';').ToList();
    var pcsList = pcs.Split(';').ToList();
    
    var sb = new StringBuilder();
    
    using (var xw = XmlWriter.Create(sb))
    {
        xw.WriteStartElement("LINES", "urn");
    
        for (int i = 0; i < posList.Count; i++)
        {
            xw.WriteStartElement("RECEIVE_EINVOICE_LINE", "urn");
    
            xw.WriteElementString("C00", "urn", posList[i]);
            xw.WriteElementString("C14", "urn", desList[i]);
            xw.WriteElementString("D00", "urn", pcsList[i]);
    
            xw.WriteEndElement();
        }
    
        xw.WriteEndElement();
    }
    
    var soapMessage = sb.ToString();
