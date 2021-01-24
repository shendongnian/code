    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement test = new XElement("test", new object[] {
                    new XAttribute("tip", "abc"),
                    2560602000
                });
            }
        }
    }
