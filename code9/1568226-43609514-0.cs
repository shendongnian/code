    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication49
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement dataClass = new XElement("DataClass");
                for(int i = 1; i <= 3; i++)
                {
                    XElement field = new XElement("Field" + i.ToString(), new object[] {
                        new XAttribute("code", "code#" + i.ToString()),
                        "Value of Field" + i.ToString()
                    });
                    dataClass.Add(field);
                }
            }
        }
    }
