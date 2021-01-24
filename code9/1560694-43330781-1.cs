    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Ryggsäcken
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                bool running = true;//Ger ett booleskt värde till variabeln     running för att kunna skapa en loop
                while (running)//Här skapas loopen
                {
                    List<string> mylist = new List<string> { };
                    string[] answer = new string[5];
                    Console.WriteLine("\nVälkommen till ryggsäcken!");
                    Console.WriteLine("\n[1] Lägg till flera föremål i stora facket");
                    Console.WriteLine("[2] Lägg till 4 föremål i lilla facket");
                    Console.WriteLine("[3] Skriv ut innehållet i stora facket");
                    Console.WriteLine("[4] Skriv ut inehållet i lilla facket");
                    Console.WriteLine("[5] Avsluta");
                    Console.Write("\nVälj: ");
    
                    int option = Convert.ToInt32(Console.ReadLine());//Konverterar från string till Int
    
    
                    switch (option)
                    {
                        case 1:
                            Console.Write("Lägg till föremål i ryggsäcken: ");
                            
                            mylist.Add(Console.ReadLine());
                            mylist.Add(Console.ReadLine());
                            mylist.Add(Console.ReadLine());
                            mylist.Add(Console.ReadLine());
                            mylist.Add(Console.ReadLine());
                            mylist.Add(Console.ReadLine());
                            break;
    
                        case 2:
                            Console.WriteLine("Skriv in 4 föremål");
                  
                            for (int i = 0; i < answer.Length; i++)
                            {
                                answer[i] = Console.ReadLine();
                            }
                            break;
    
    
    
                        case 3:
                            if (mylist.Length > 0)
                            foreach (string item in mylist)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case 4:
                             if (answer.Count > 0)
                             Console.WriteLine(answer[i]);
                             break;
    
                         case 5:
                            running = false;
    
                    }
                }
             }
        }
    
    }
