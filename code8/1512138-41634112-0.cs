    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication42
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement book = new XElement("book", new object[] {
                    new XElement("title","Pride And Prejudice")
                });
      
            }
        }
    }
 
