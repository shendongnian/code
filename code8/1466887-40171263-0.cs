    var certificate = new X509Certificate2(keyFile, "notasecret", X509KeyStorageFlags.Exportable);
    try{
       ServiceAccountCredential credential = new ServiceAccountCredential(
          new ServiceAccountCredential.Initializer(serviceAccountEmail)
          {
              Scopes = scopes
          }.FromCertificate(certificate));
       
       //Create the service.
       DriveService service = new DriveService(new BaseClientService.Initializer()
       {
          HttpClientInitializer = credential,
          ApplicationName = "Drive API Sample"
       });
       return service;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.InnerException);
        return null;
    }
