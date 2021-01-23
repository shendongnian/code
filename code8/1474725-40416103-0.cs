     XmlElement root = returnXmlFile.DocumentElement;
             XmlNodeList nodes = root.ChildNodes;
             for (int i = 0; i < nodes.Count; i++)
             {
                 string OuterIDvalue = nodes[i].ChildNodes[0].InnerText.ToString();
                 const int idVal = 1;
                 int counter = 1;
                 if (nodes[i].FirstChild.Attributes.Count == 0)
                 {
                     for (int ctrInner = 0; ctrInner < nodes[i].ChildNodes.Count; ctrInner++)
                     {
                         XmlAttribute xKey = returnXmlFile.CreateAttribute("id");
                         xKey.Value = idVal.ToString();
                         nodes[i].ChildNodes[ctrInner].Attributes.Append(xKey);
                     }
                 }      
                     for (int j = i + 1; j < nodes.Count; j++)
                     {
                         string innerIDvalue = nodes[j].ChildNodes[0].InnerText.ToString();
                         if (OuterIDvalue == innerIDvalue && nodes[j].FirstChild.Attributes.Count == 0)
                         {
                             counter++;
                             for (int ctr = 0; ctr < nodes[j].ChildNodes.Count; ctr++)
                             {
                                 XmlAttribute xKey = returnXmlFile.CreateAttribute("id");
                                 xKey.Value = counter.ToString();
                                 nodes[j].ChildNodes[ctr].Attributes.Append(xKey);
                             }
                         }
                     }
             }
             string xmlnew = returnXmlFile.InnerXml;
             returnXmlFile.Save(FileName);
            return xmlnew;
        }
