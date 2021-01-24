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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Book.books = doc.Descendants("books").FirstOrDefault().Elements().Select(x => new Book() {
                    name = x.Name.LocalName,
                    author = (string)x.Element("author"),
                    detail = (string)x.Element("details")
                }).ToList();
            }
        }
        public class Book
        {
            public static List<Book> books = new List<Book>();
            public string name { get; set;}
            public string author { get; set;}
            public string detail { get; set;}
        }
     
    }
