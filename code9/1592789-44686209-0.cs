        public class ExcelNameSpaceXmlTextReader : XmlTextReader
        {          
     
             public ExcelNameSpaceXmlTextReader(System.IO.TextReader reader)
                : base(reader) { }
        
            public override string NamespaceURI
            {
                get { return ""; }
            }
        }
