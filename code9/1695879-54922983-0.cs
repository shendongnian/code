        JavaScriptSerializer ser = new JavaScriptSerializer();
    string applicationHostFile = @"C:\Windows\System32\inetsrv\Config\applicationHost.config";
    using (System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(applicationHostFile))
    {
        System.Xml.Serialization.XmlSerializer DeSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Xml2CSharp.Configuration));
        Xml2CSharp.Configuration configuration = (Xml2CSharp.Configuration)DeSerializer.Deserialize(reader);
        foreach (var site in configuration.SystemapplicationHost.Sites.Site)
        {
            // clear Application to not expose sensitive information
            site.Application = null;
            Console.WriteLine(site.Name);
            foreach (var binding in site.Bindings.Binding)
            {
                Console.WriteLine(binding.BindingInformation);
            }
        }
    }
