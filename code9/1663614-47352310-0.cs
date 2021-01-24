    var fClient = new FabricClient();
    var namespaceManager = new XmlNamespaceManager(new NameTable());
    namespaceManager.AddNamespace("ns", "http://schemas.microsoft.com/2011/01/fabric");
    var manifest = XDocument.Parse(fClient.ApplicationManager.GetApplicationManifestAsync("YOUR_APP_TYPE_NAME", "YOUR_APP_TYPE_VERSION").Result);         
    var parameterValue = manifest.XPathSelectElement("/ns:ApplicationManifest/ns:Parameters/ns:Parameter[@Name='PARAMETER_NAME']", namespaceManager).Attribute("DefaultValue").Value;
