    const string BASE_ADDRESS = 
    "http://localhost:8731/Design_Time_Addresses/CalcService";
    var uri = new Uri(BASE_ADDRESS);
    var user = "userName";
    
    using (var serviceHost = new ServiceHost(typeof(Calc), uri))
    {
      var exporter = new WsdlExporter();
      var endpoint = serviceHost.AddServiceEndpoint(typeof(ICalc),
      new BasicHttpBinding(), "");
      endpoint.Contract.Behaviors.Add(new
      RestrictedOperationsWsdlExportExtensionAttribute(user));
      serviceHost.Open();
      Console.WriteLine("The service is ready: " + user);
      exporter.ExportEndpoint(endpoint);
      if (exporter.Errors.Count == 0)
      {
        var metadataSet = exporter.GetGeneratedMetadata();
        var asy= Assembly.GetAssembly(typeof(WsdlExporter));
        var t = asy.GetType("System.ServiceModel.Description.WsdlHelper",
          true);
        var method = t.GetMethod("GetSingleWsdl", 
          System.Reflection.BindingFlags.Public 
          | System.Reflection.BindingFlags.Static);
        var serviceDescription =
          method.Invoke(null, new object[] {metadataSet})
          as System.Web.Services.Description.ServiceDescription;
        if (serviceDescription != null)
        {
          serviceDescription.Name = "Calc";
          serviceDescription.Write(user + ".wsdl");
        }
      }
    }	
