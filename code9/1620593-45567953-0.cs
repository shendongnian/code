    public class CustomXmlWriter : XmlWriter
            {
                public override XmlWriterSettings Settings
                {
                    get
                    {
                        // for this you can use method as well
                        var settings = new XmlWriterSettings();
                        settings = new XmlWriterSettings();
                        settings.Indent = true;
                        settings.IndentChars = ("\t");
                        settings.OmitXmlDeclaration = true;
                        return settings;
                    }
                }
            
            }
