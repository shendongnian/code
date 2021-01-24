    private XmlNode CreateXPath(XmlDocument doc, string xpath, string parameter, string value)
    {
      return CreateXPath(doc, doc as XmlNode, xpath, parameter, value);
    }
    
    private XmlNode CreateXPath(XmlDocument doc, XmlNode parent, string xpath, string parameter, string value)
    {
       string[] partsOfXPath = xpath.Trim('/').Split('/');
       string nextNodeInXPath = partsOfXPath.First();
       if (string.IsNullOrEmpty(nextNodeInXPath))
       {
          if (parent.Attributes[parameter] == null && parent.LocalName == xpath)
          {
            // Attribute not found, create it                        
            ((XmlElement)parent).SetAttribute(parameter, value);
          }
          return parent;
        }
    
        XmlNode node = parent.SelectSingleNode(nextNodeInXPath);
        if (node == null)
        {
           // node not found, create it and additionally add attributes                    
           node = parent.AppendChild(doc.CreateElement(nextNodeInXPath));
           ((XmlElement)node).SetAttribute(parameter, value);
        }
        // Call recursive
        string rest = String.Join("/", partsOfXPath.Skip(1).ToArray());
        return CreateXPath(doc, node, rest, parameter, value);
     }
