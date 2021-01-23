    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xml = @"<InvalidDocTypes>
      <DocType>DocType1</DocType>
      <DocType>DocType2</DocType>
    </InvalidDocTypes>";
    
                var documentType = "DocType1";
    
                var xmlDocument = XDocument.Parse(xml);
                var node = xmlDocument.XPathSelectElement("//InvalidDocTypes[DocType='" + documentType + "']");
                Console.WriteLine(node);
            }
        }
    }
