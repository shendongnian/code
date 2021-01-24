    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable = false)]
    public class TimbreFiscalDigital
    {
        string versionField;
        //[XmlAttribute]
        public string version { get { return versionField; } set { versionField = value; } }
	
		[XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns 
        {
            get
            {
				return new XmlSerializerNamespaces()
					.With("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
					.With("xsi", XmlSchema.InstanceNamespace);
            }
			set { /* Do nothing */ }
        }
		
		[XmlAttribute("schemaLocation", Namespace = XmlSchema.InstanceNamespace)]
		public string xsiSchemaLocation = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd";
        public TimbreFiscalDigital()
        {
            this.versionField = "1.1";
        }
    }
