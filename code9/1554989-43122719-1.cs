        static void Main(string[] args)
        {
            string nugget = @"C:\Users\mikes\Documents\Nugget.txt";
            string[] arrText = File.ReadAllLines(nugget);
            int menuWidth = 89;
            string bar = new string('═', menuWidth - 2);
            Console.Clear();
            Console.WriteLine("╔" + bar + "╗");
            Console.Write("║ProID\tProduct Name\tPrice\tStock");
            Console.SetCursorPosition(menuWidth - 1, Console.CursorTop);
            Console.WriteLine("║");
            Console.WriteLine("╠" + bar + "╣");
            
            foreach (string sOutput in arrText)
            {   
                Console.Write(sOutput);
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("║");
                Console.SetCursorPosition(menuWidth - 1, Console.CursorTop);
                Console.WriteLine("║");
            }
            Console.WriteLine("╚" + bar + "╝");
            Console.WriteLine("");
            Console.ReadLine();
        }
