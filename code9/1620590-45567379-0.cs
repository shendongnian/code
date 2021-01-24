    static class XmlHelper {
        public static XmlWriterSettings GetCustomSettings() {
            return new XmlWriterSettings {
                Indent = true,
                IndentChars = ("\t"),
                OmitXmlDeclaration = true
            };
        }
    }
