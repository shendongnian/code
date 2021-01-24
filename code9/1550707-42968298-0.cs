    XmlDocument DOC = new XmlDocument();
    DOC.Load("LoadYourXMLHere.xml");
    XmlNodeList ParentNode = DOC.GetElementsByTagName("customer");
    foreach (XmlNode AllNodes in ParentNode)
    {
     if (ParentNode == DOC.GetElementsByTagName("customerMiddleInitial"))
    {
        customer.Initial = AllNodes["customerMiddleInitial"].InnerText;
    }
    if (ParentNode == DOC.GetElementsByTagName("name"))
    {
        customer.FirstName= AllNodes["FirstName"].InnerText;
        customer.LastName= AllNodes["LastName"].InnerText;
    }
    if (ParentNode == DOC.GetElementsByTagName("customerBirth"))
    {
        customer.Birthdate= AllNodes["customerBirth"].InnerText;
    }
    if (ParentNode == DOC.GetElementsByTagName("customerWorkPhone"))
    {
        customer.WorkPhone= AllNodes["customerWorkPhone"].InnerText;
    }
    if (ParentNode == DOC.GetElementsByTagName("customerMobilePhone"))
    {
        customer.MobilePhone = AllNodes["customerMobilePhone"].InnerText;
    }
    if (ParentNode == DOC.GetElementsByTagName("previousCust"))
    {
        customer.PreviousCust= AllNodes["previousCust"].InnerText;
    }
    if (ParentNode == DOC.GetElementsByTagName("timeOnFile"))
    {
        customer.TimeOnFile= AllNodes["timeOnFile"].InnerText;
    }
    if (ParentNode == DOC.GetElementsByTagName("customerId"))
    {
        customer.ID= AllNodes["customerId"].InnerText;
    }
    } 
