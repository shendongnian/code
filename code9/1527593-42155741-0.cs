    Console.WriteLine("Hello, World!");
    string s = "<DataItem type=\"System.PropertyBagData\" time=\"2017-02-03T09:50:29.1118296Z\" sourceHealthServiceId=\"\"><Property Name=\"LoggingComputer\" VariantType=\"8\">g2aaS03OsX/9e5SSikdrVjFb4tkwhVUWeGh6pOv8nJ0=</Property><Property Name=\"EventDisplayNumber\" VariantType=\"8\">4502</Property><Property Name=\"ManagementGroupName\" VariantType=\"8\">/=</Property><Property Name=\"RuleName\" VariantType=\"8\">CollectNetMonInformation</Property><Property Name=\"ModuleTypeName\" VariantType=\"8\"></Property><Property Name=\"StackTrace\" VariantType=\"8\">System.Exception: [2/3/2017 9:50:29 AM][InitializeDataReceiver]: 2 WaitNamedPipe Error : 2 Pipe guid is : </Property></DataItem>";
    XmlDocument xml = new XmlDocument();
    xml.LoadXml(s);
    XmlNodeList xnList = xml.SelectNodes("/DataItem");
    foreach (XmlNode xn in xnList)
    {
        XmlNodeList propsList = xn.SelectNodes("Property");
        foreach (XmlNode node in propsList)
        {
            string firstName = node.InnerText;
            Console.WriteLine(firstName);
        }
    }
