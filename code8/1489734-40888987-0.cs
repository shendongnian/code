    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication29
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument xdoc = XDocument.Load(FILENAME);
                    foreach (var iDescription in xdoc.Descendants("test"))
                    {
                         string lang = (string)iDescription.Attribute("language"); // en / it / hu / es
                         string text= (string)iDescription; // hello or ciao ...
                         switch(lang)
                         {
                              case "en":
                              // do something
                              break;
                              case "it":
                              // do something
                              break;
                              case "hu":
                              // do something
                              break;
                              case "es":
                              // do something
                              break;
                         }
                     }
            }
     
        }
        
    }
 
