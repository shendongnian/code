    using System;
    using System.Xml.Linq;
    
    public class Test
    {
        static void Main(string[] args)
        {
            XNamespace ns = "urn:schemas-microsoft-com:office:spreadsheet";
            var doc = new XDocument(   
                new XDeclaration("1.0", "utf-8", "yes"),   
                new XProcessingInstruction("mso-application", "Excel.Sheet"),   
                new XElement(ns + "Workbook",
                    new XAttribute("xmlns", ns),
                    new XAttribute(XNamespace.Xmlns + "ss", ns),
                    new XElement(ns + "Worksheet", 
                       new XAttribute(ns + "Name", "my-table-name"),
                       new XElement(ns + "Table")
                    )
                )
            );
            Console.WriteLine(doc);
        }
    }
