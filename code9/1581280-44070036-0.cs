    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication3
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            public static void Main(string[] args)
            {
                new Book(FILENAME);
            }
        }
        public class Book
        {
            public static List<Book> books = new List<Book>();
            string id { get; set; }
            string title { get; set; }
            string author { get; set; }
            public Book() { }
            public Book(string filename)
            {
                XmlReader reader = XmlReader.Create(filename);
                while (!reader.EOF)
                {
                    if (reader.Name != "book")
                    {
                        reader.ReadToFollowing("book");
                    }
                    if (!reader.EOF)
                    {
                        Book newBook = new Book();
                        books.Add(newBook);
                        XElement xmlBook = (XElement)XElement.ReadFrom(reader);
                        newBook.id = (string)xmlBook.Attribute("id");
                        newBook.author = (string)xmlBook.Element("author");
                        newBook.title = (string)xmlBook.Element("title");
                    }
                }
            }
        }
    }
