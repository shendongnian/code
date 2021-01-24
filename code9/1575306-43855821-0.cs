    using System;
    using System.Collections.Generic;
    using System.IO;
    
    abstract class Book
    {
        protected String title;
        protected String author;
        public Book(String t, String a)
        {
            this.title = t;
            this.author = a;
        }
        public abstract void display();
    }
    class MyBook : Book
    {
        private int price = 0;
        public MyBook(string t, string a, int p) : base(t, a) // Let the base class decide what it wants to do with these arguments
        {
            this.price = p;
        }
        public override void display()
        {
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Price: {price}");
        }
    }
