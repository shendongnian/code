    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Book> books = new List<Book>() {
                   new Book() { name = "A", authors = new List<string>() { "AuthorA", "AuthorB","AuthorC"}},
                   new Book() { name = "B", authors = new List<string>() { "AuthorD", "AuthorE","AuthorF"}},
                   new Book() { name = "C", authors = new List<string>() { "AuthorG", "AuthorH","AuthorI"}},
                   new Book() { name = "D", authors = new List<string>() { "AuthorJ", "AuthorK","AuthorL"}},
                   new Book() { name = "E", authors = new List<string>() { "AuthorM", "AuthorN","AuthorO"}}
               };
                var orderedBook = books.OrderBy(x => x.authors.FirstOrDefault()).ToList();
            }
        }
        public class Book
        {
            public string name { get; set; }
            public List<string> authors { get; set; }
        }
    }
