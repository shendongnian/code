    XmlDocument doc = new XmlDocument();
    doc.LoadXml(txtQuery.Text);
    DisplayNodes(doc.DocumentElement);
     private static void DisplayNodes(XmlNode node)
     {
      //Print attributes of the node
      if (node.Attributes != null)
       {
         XmlAttributeCollection attrs = node.Attributes;
         string value = string.Empty;
         foreach (XmlAttribute attr in attrs)
         {
           if (attr.Name == "fdtLorenzoField")
               value = attrs["fdtFieldName"]?.InnerText;
    
           Console.WriteLine("Attribute Name: fdtFieldName, Attribute Value = " + value);
          }
      }
    }
