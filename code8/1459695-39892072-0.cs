    using System.Xml;
    XmlNodeList elemList = doc.GetElementsByTagName(@"XML node");
    
                    for (int i = 0; i < elemList.Count; i++)
                    {
                        //dosomthing with   
                        elemList[i].Attributes["AttributeName"].Value;
                    }  
