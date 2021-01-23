    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication16
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement msrProgram = new XElement("MsrProgram", new object[] {
                    new XAttribute("OwnerTypeFullName","myData"),
                    new XAttribute("Number", 0),
                    new XElement("MsrRange2Width",4)
                });
     
            }
        }
    }
