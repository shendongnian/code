            string input = string.Empty;
            int x = 0;
            do
            {
                input = Console.ReadLine();
            } while (int.TryParse(input, out x));
            Console.WriteLine("Invalid entry");
            
            Console.ReadKey();
