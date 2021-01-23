    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace LibraryWork
    {
    
        class Program
        {
            static void Main(string[] args)
            {
                var bookList = new List<string>();
                if(File.Exists("books.txt")) //Check if file exists.
                {
                    bookList = File.ReadAllLines("books.txt").ToList(); //Load the file and convert it to a list.
                }
                string ansSearch = String.Empty;
                string search = String.Empty;
                int i = 1;
                for (int zero = 0; i > zero; i++)
                {
                    Console.Write("Type ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("'New'");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" if you would you like to enter a new book. Type ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("'List' ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("to see a list of books entered. Type ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("'Search' ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("to look up a specific book.");
                    Console.Write(" And if you want to exit. Type ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("'Stop'.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
    
    
    
    
                    string answer = Console.ReadLine();
    
                    if (answer == "Stop")
                    {
                        break; //Escape the loop.
                    }
    
                    if (answer == "New")
                    {
                        Console.Write("Please format the Entry of your book as follows: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("'Name of the Book',");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("'Author (first, last)',");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("'Category',");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("'Dewey Decimal Number'.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        bookList.Add("Entry " + i + ": " + Console.ReadLine());
                        continue;
                    }
                    if (answer == "List")
                    {
                        bookList.ForEach(Console.WriteLine);
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        i--;
                        continue;
                    }
                    if (answer == "Search")
                    {
                        Console.WriteLine("What would you like to search for (Title: Full Title; Author: first, last): ");
                        search = Console.ReadLine();
                        var results = bookList.Where(x => x.Contains(search)).ToList();
                        bool isEmpty = !results.Any();
                        if (isEmpty)
                        {
                            i--;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry, we could not find that.");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        foreach (var result in results)
                        {
                            Console.WriteLine(result);
    
                        }
    
    
    
    
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        results.Clear();
                        i--;
                        continue;
                    }
                    i--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect Response, please try again");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //We end up here after breaking from the loop.
                File.WriteAllLines("books.txt", bookList); //Save our list of books.
            }
        }
    
    }
