    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                string catalog = System.IO.File.ReadAllText("catalog.xml");
    
                System.Xml.Linq.XDocument xdoc = System.Xml.Linq.XDocument.Parse(catalog);
    
                var targetBook = xdoc.XPathSelectElement("//catalog/book[@id='bk101']");
                var targetBookTitle = targetBook.XPathSelectElement("title").Value;
                var targetBookAuthor = targetBook.XPathSelectElement("author").Value;
    
                Console.Write($"{ targetBookTitle} - { targetBookAuthor}");
                Console.Read();
    
            }
        }
    }
