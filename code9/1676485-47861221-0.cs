    [XmlSchemaProvider("GetSchemaMethod")]
    public partial class PersonDTO : IXmlSerializable
    {
        // This is the method named by the XmlSchemaProviderAttribute applied to the type.
        public static XmlQualifiedName GetSchemaMethod(XmlSchemaSet xs)
        {
            // Fill in a plausible schema for the type if necessary.
            // 
            // While DataContractSerializer will not use the returned schema set, 
            // svcutil.exe will use it to generate schemas.  XmlSerializer also
            // seems to require it to be initialized to something plausible if you
            // are serializing your types with both serializers.
            string personSchema = @"<xs:schema xmlns:tns=""http://www.MyCompany.com"" elementFormDefault=""qualified"" targetNamespace=""http://www.MyCompany.com"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
      <xs:element name=""Person"" nillable=""true"" type=""tns:Person"" />
      <xs:complexType name=""Person"">
        <xs:attribute name=""name"" type=""xs:string"" />
      </xs:complexType>
    </xs:schema>";
            using (var textReader = new StringReader(personSchema))
            using (var schemaSetReader = System.Xml.XmlReader.Create(textReader))
            {
                xs.Add("http://www.MyCompany.com", schemaSetReader);
            }
            // Return back the namespace and name to be used for this type.
            return new XmlQualifiedName("Person", "http://www.MyCompany.com");
        }
    }
