    // Allocate the XDocument and add an XML declaration.  
    XDocument RejectedXmlList = new XDocument(new XDeclaration("1.0", "utf-8", null));
    // At this point RejectedXmlList.Root is still null, so add a unique root element.
    RejectedXmlList.Add(new XElement("Rejectedparameters"));
    // Add elements for each Parameter to the root element
    foreach (Parameter Myparameter in Parameters)
    {
        if (true)
        {
            XElement xelement = new XElement(Myparameter.ParameterName, CurrentData.ToString());
            RejectedXmlList.Root.Add(xelement);
        }
    }
