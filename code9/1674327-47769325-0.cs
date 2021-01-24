    string xml = File.ReadAllText(xmlfilePath, Encoding.GetEncoding("SHIFT_JIS"));
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xml); 
                        if (doc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
                            doc.RemoveChild(doc.FirstChild);
                        xml = GetXMLAsString(doc);
    
    
     public string GetXMLAsString(XmlDocument myxml)
            {
    
                StringWriter sw = new StringWriter();
                XmlTextWriter tx = new XmlTextWriter(sw);
                myxml.WriteTo(tx);
    
                string str = sw.ToString();// 
                return str;
            }
