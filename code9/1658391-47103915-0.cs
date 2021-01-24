    ...    
    xmlString = System.IO.File.ReadAllText("myXMLDoc.xml");
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.CloseInput = true;
    settings.ValidationEventHandler += ValidationHandler;
    settings.ValidationType = ValidationType.Schema;
    settings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings |
                           XmlSchemaValidationFlags.ProcessIdentityConstraints |
                           XmlSchemaValidationFlags.ProcessSchemaLocation |
                           XmlSchemaValidationFlags.ProcessInlineSchema;
        
    StringReader r = new StringReader(xmlString);
    XmlReader validatingReader = XmlReader.Create(r, settings);
    XmlDoc = new XmlDocument();
    XmlDoc.Load(validatingReader);
    ...
    
    private static void ValidationHandler(object sender, ValidationEventArgs e)
    {
      if (e.Severity == XmlSeverityType.Error || e.Severity == XmlSeverityType.Warning)
        {
          validationErr += "XML Parse Error Line: " +
                             e.Exception.LineNumber + " Position: " +
                             e.Exception.LinePosition + " Message: " +
                             e.Exception.Message + Environment.NewLine;
         }
    }
