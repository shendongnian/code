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
                string header = 
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<d:dictionary xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:d=\"http://www.apple.com/DTDs/DictionaryService-1.0.rng\">" +
                    "</d:dictionary>";
                XDocument doc = XDocument.Parse(header);
                XElement dictionary = (XElement)doc.FirstNode;
                XNamespace dNs = dictionary.GetNamespaceOfPrefix("d");
                XNamespace defaultNs = dictionary.GetDefaultNamespace();
                XElement newDict = new XElement(dNs + "entry", new object[] {
                    new XAttribute("id", "dictionary_application"),
                    new XAttribute("title","Dictionary application"),
                    new XElement(dNs + "index", new XAttribute("value", "Dictionary application")),
                    new XElement(defaultNs + "h1", "Dictionary application"),
                    new XElement(defaultNs + "p", "An application to look up in dictionary on Mac OS X.")
                });
                dictionary.Add(newDict);
            }
        }
        
    }
