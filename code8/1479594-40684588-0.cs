    var test = new SoapFaultException { faultcode = "", faultstring = "Hello World" };
    var serializer = new DataContractSerializer(typeof(SoapFaultException));
    var doc = new XDocument();
    using (var writer = doc.CreateWriter())
    {
        serializer.WriteObject(writer, test);
    }
    // Add the iopbase prefix for clarity
    doc.Root.Add(new XAttribute(XNamespace.Xmlns + "iopbase", "http://example.com/foo/"));
    Debug.WriteLine(doc);
