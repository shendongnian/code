    string sKeyFile = System.Web.Hosting.HostingEnvironment.MapPath("/Keys/" + ServiceAccountKey);
    if (!System.IO.File.Exists(sKeyFile))
    {
        throw new Exception("Key file can't be found! " + sKeyFile);
    }
    var certificate = new X509Certificate2(sKeyFile, "notasecret", 
                       X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);
