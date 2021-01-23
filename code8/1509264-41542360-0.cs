    XElement element = xml.Root.Elements("BusinessRule").Where(xElement => xElement.Element("Type").Value == "Hierarchy_RestrictedOperations").FirstOrDefault();
           
            if(element != null)
            {
                element.Element("Enabled").Value = "FALSE";
            }
            xml.Save("R:\\config\\ProductCatalog\\PCConfig.xml");
