        public static bool IsValidXml1(string xmlFilePath, string xsdFilePath, string namespaceName)
        {
            XDocument xdoc = null;
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Ignore;
            try
            {
                using (XmlReader xr = XmlReader.Create(xmlFilePath, settings))
                {
                    xdoc = XDocument.Load(xr);
                    var schemas = new XmlSchemaSet();                    
                    schemas.Add(namespaceName, xsdFilePath);                   
                    using (var fs = File.OpenRead(@"D:\Temp\xmldsig-core-schema.xsd")) 
                    using (var reader = XmlReader.Create(fs, new XmlReaderSettings() {
                        DtdProcessing = DtdProcessing.Ignore // important
                    })) {
                        schemas.Add(@"http://www.w3.org/2000/09/xmldsig#", reader);
                    }
                    
                    xdoc.Validate(schemas, null);
                    return true;
                }
            }
            catch (XmlSchemaValidationException ex)
            {
                // throw;
            }
            return false;
        }
