    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static List<book> _booksList = new List<book>();
            static Hashtable _ht = new Hashtable();
            static void Main(string[] args)
            {
                _ht.Add(BookTypes.Roman, "Roman");
                _ht.Add(BookTypes.Journal, "Journal");
                _ht.Add(BookTypes.StoryCollection, "Collection of stories");
    
                Console.WriteLine("\t Hello and welcome to the library!");
                int userInput;
                bool isRunning = true;
                while (isRunning)
                {
                    Console.WriteLine("\n\t[1] Add a book" +
                        "\n\t[2] Show Books" +
                        "\n\t[3] End program");
                    Console.Write("\n\tSelect: ");
                    Int32.TryParse(Console.ReadLine(), out userInput);
                    switch (userInput)
                    {
                        case 1:
                            Console.Clear();
                            RegisterBook();
                            break;
                        case 2:
                            Console.Clear();
                            ShowAllBooks();
                            break;
                        case 3:
                            isRunning = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("\n\tDu kan endast välja 1-3 i menyn.");
                            break;
                    }
                }
            }
            static void RegisterBook()
            {
                book bok = new book();
                Console.Write("\n\tEnter Title: ");
                bok.Title = Console.ReadLine();
                Console.Write("\n\t Author : ");
                bok.Author = Console.ReadLine();
                Console.Write("\n\tEnter Type of book - Roman-1, Journal-2, Collection of stories-3?: ");
                bok.BookType = (BookTypes)Convert.ToInt32(Console.ReadLine());
                _booksList.Add(bok);
                Console.WriteLine("\n\t Added Book Successfully !");
                Console.ReadLine();
                Console.Clear();
            }
            public static void ShowAllBooks()
            {
                for (int i = 0; i < _booksList.Count; i++)
                {
                    Console.WriteLine("\t" +" Title: "+ _booksList[i].Title + " Author: " + _booksList[i].Author+ " Type: " + _ht[_booksList[i].BookType].ToString());
                }
            }
        }
        public class book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public BookTypes BookType { get; set; }
        }
        public enum BookTypes
        {
            Roman=1,
            Journal=2,
            StoryCollection=3
        }
    }
