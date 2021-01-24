    Unhandled Exception: System.Xml.XmlException: For security reasons DTD is prohibited in this XML document. To enable DTD processing set the DtdProcessing property on XmlReaderSettings to Parse and pass the settings into XmlReader.Create method.
       at System.Xml.XmlTextReaderImpl.Throw(Exception e)
       at System.Xml.XmlTextReaderImpl.ParseDoctypeDecl()
       at System.Xml.XmlTextReaderImpl.ParseDocumentContent()
       at System.Xml.Schema.Parser.StartParsing(XmlReader reader, String targetNamespace)
       at System.Xml.Schema.Parser.Parse(XmlReader reader, String targetNamespace)
       at System.Xml.Schema.XmlSchemaSet.ParseSchema(String targetNamespace, XmlReader reader)
       at System.Xml.Schema.XmlSchemaSet.Add(String targetNamespace, String schemaUri)
