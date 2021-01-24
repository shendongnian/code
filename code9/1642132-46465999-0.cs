         string firstName; 
         XmlReader xmlReader = XmlReader.Create(new System.IO.StringReader(rpd.formmodeler));
         while (xmlReader.Read())
         {
          if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "g"))
             {
                 var firstNameElement = xmlReader.GetAttribute("fdtLorenzoField");
                    if (firstNameElement.IsNotNullOrEmpty())
                         {
                           firstName = xmlReader.GetAttribute("fdtFieldName");
                         }
                }
        }
