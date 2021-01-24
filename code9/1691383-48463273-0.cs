    private static void WriteWCFConfig()
    {
        //standard method from System.Configuration 
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //the main section in the app.config file for WCF 
        ServiceModelSectionGroup serviceModel = ServiceModelSectionGroup.GetSectionGroup(appConfig);
        var httpBindings = serviceModel.Bindings.BasicHttpBinding;
        if (!httpBindings.ContainsKey("InvioTelematicoSS730pMtomPortBinding"))
        {
            BasicHttpBindingElement newHttpBindng = new BasicHttpBindingElement("InvioTelematicoSS730pMtomPortBinding");
            newHttpBindng.MessageEncoding = WSMessageEncoding.Mtom;
            newHttpBindng.Security.Mode = BasicHttpSecurityMode.Transport;
            httpBindings.Bindings.Add(newHttpBindng);
        }
        if (!httpBindings.ContainsKey("RicevutaPdf730PortBinding"))
        {
            BasicHttpBindingElement newHttpBindng = new BasicHttpBindingElement("RicevutaPdf730PortBinding");
            newHttpBindng.MessageEncoding = WSMessageEncoding.Mtom;
            newHttpBindng.Security.Mode = BasicHttpSecurityMode.Transport;
            httpBindings.Bindings.Add(newHttpBindng);
        }
        //the section 
        ChannelEndpointElementCollection endPoints = serviceModel.Client.Endpoints;
        //Get endpoint names
        List<string> endpointNames = new List<string>();
        foreach (ChannelEndpointElement endpointElement in endPoints)
        {
            endpointNames.Add(endpointElement.Name);
        }
        if (!endpointNames.Contains("InvioTelematicoSS730pMtomPort"))
        {
            ChannelEndpointElement endPoint = new ChannelEndpointElement(new EndpointAddress("http://localhost:9080/InvioTelematicoSS730pMtomWeb/InvioTelematicoSS730pMtomPort"), "InvioFlussi730.InvioTelematicoSS730pMtom");
            endPoint.Name = "InvioTelematicoSS730pMtomPort";
            endPoint.Binding = "basicHttpBinding";
            endPoint.BindingConfiguration = "InvioTelematicoSS730pMtomPortBinding";
            endPoints.Add(endPoint);
        }
        if (!endpointNames.Contains("RicevutaPdf730Port"))
        {
            ChannelEndpointElement endPoint = new ChannelEndpointElement(new EndpointAddress("https://invioSS730pTest.sanita.finanze.it/Ricevute730ServiceWeb/ricevutePdf"), "ServiceReference1.RicevutaPdf730");
            endPoint.Name = "RicevutaPdf730Port";
            endPoint.Binding = "basicHttpBinding";
            endPoint.BindingConfiguration = "RicevutaPdf730PortBinding";
            endPoints.Add(endPoint);
        }
        appConfig.Save();
    }
