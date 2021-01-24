    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication3
    {
        using System;
    
        namespace MasterMind
        {
            class Menu
            {
                public void DrawMainMenu()
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("               MasterMind's Main Menu");
                    Console.WriteLine("                    1: Play");
                    Console.WriteLine("                    2: Help");
                    Console.WriteLine("                    0: Exit");
                }
                public void DrawHelp()
                {
                    Console.Clear();
                    Console.WriteLine("Rules Of MasterMind!");
                    Console.WriteLine("Mastermind is a game about guessing a 4 digit code. The numbers can range from");
                    Console.WriteLine("1-4 and any other numbers will be rejected. It will say in the CMD");
                    Console.WriteLine("prompt whether or not you had any of the number correct or false.");
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadKey();
                    Console.Clear();
                }
                public void DrawExit()
                {
                    Console.Clear();
                    Console.WriteLine("You are about to exit the game");
                    Console.WriteLine("Are you sure: Y/N");
                    string userExit = Console.ReadKey().KeyChar.ToString();
                    if (userExit == "Y")
                    {
                        Environment.Exit(0);
                    }
                    if (userExit == "N")
                    {
                        Console.Clear();
                    }
                }
            }
            class Program
            {
                static void Main(string[] args)
                {
                    var menu = new Menu();
    
                    while (true)
                    {
                        menu.DrawMainMenu();
    
                        string userInput = Console.ReadKey().KeyChar.ToString();
                        if (userInput == "1")
                        {
                            // play
                        }
                        if (userInput == "2")
                        {
                            menu.DrawHelp();
                        }
                        if (userInput == "0")
                        {
                            menu.DrawExit();
                        }
                    }
    
                    Console.ReadLine();
                }
            }
        }
    }
