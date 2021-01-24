    static void Main(string[] args)
        {
            bool isRunning = true;
            string item = "Empty space";
            while (isRunning)
            {
                Console.WriteLine("\n\tWelcome to the backpack!");
                Console.WriteLine("\t[1]Add an item");
                Console.WriteLine("\t[2]Show contents");
                Console.WriteLine("\t[3]Clear contents");
                Console.WriteLine("\t[4]Exit");
                Console.Write("\tChoose: ");
    
                int menyVal = Convert.ToInt32(Console.ReadLine());
    
                switch (menyVal)
                {
                    case 1:
                        Console.WriteLine("\n\tContents of backpack:");
                        Console.WriteLine("\n\t" + item);
                        Console.WriteLine("\n\tWhat do you want to replace " + item + " with?");
                        item = item.Replace(item, Console.ReadLine()); 
                        Console.WriteLine("\n\tYou have packed " + item + " in your backpack");
                        break;
                    case 2:
                        Console.WriteLine("\n\tContents of backpack:");
                        Console.WriteLine("\n\t" + item);
                        Console.WriteLine("\n\tPress any key...");
                        Console.ReadKey();
                        break;
                    case 3:
                        item = "Tom plats";
                        Console.WriteLine("\n\tYou have emptied the backpack!");
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input!");
                        break;
                }
            }
        }
