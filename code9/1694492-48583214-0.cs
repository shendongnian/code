    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication23
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                string xml = "<Data><Caption  xmlns=\"http://www.iin.xsd\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.happy.xsd\"/></Data>";
                XDocument doc = XDocument.Parse(xml);
                XElement caption = doc.Descendants("Data").FirstOrDefault();
                caption.Add(new XElement("TemplateID","T000114-NOW"));
                XElement options = new XElement("CaptionOptions");
                caption.Add(options);
                foreach (Field field in Field.fields)
                {
                    XElement newField = new XElement("CaptionField", new object[] { new XElement("FieldID", field.ID), new XElement("TextString", field.text)});
                    options.Add(newField);
                }
     
     
            }
        }
        public class Field
        {
            public static List<Field> fields = new List<Field>() {
                new Field() {  ID = "NOW1", text = "Ep 01"},
                new Field() { ID = "Ep 01", text = ""}
            };
            public string ID { get; set; }
            public string text { get; set; }
        }
     
    }
