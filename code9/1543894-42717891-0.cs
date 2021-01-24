    private void ValidateRequest(string xmlPayload)
    {
       XmlTextReader xsdReader = null;
       XmlSchemaSet xsdSchema = null;
       XmlReaderSettings xmlReader = null;
       xsdReader = new XmlTextReader("your xsd file path here");
       xsdSchema = new XmlSchemaSet();
       xsdSchema.Add(null, xsdReader);
       xsdSchema.Compile();
       xmlReader = new XmlReaderSettings();
       xmlReader.ValidationType = ValidationType.Schema;
       xmlReader.Schemas.Add(xsdSchema);
       xmlReader.ValidationEventHandler += vr_ValidationEventHandler;
       XmlReader reader = XmlReader.Create(new StringReader(xmlPayload), xmlReader);
         while (reader.Read()) ;
         reader.Close();
    }
    void vr_ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        switch (e.Severity)
        {
            case XmlSeverityType.Error:
                throw new Exception(e.Message);
            case XmlSeverityType.Warning:
                break;
        }
    }
