     Console.Write("PLEASE ENTER YOUR FIRST AND LAST NAME: ");
            string Name = Console.ReadLine();
            Console.Write("Enter the number of times you wish for me to repeat your name, " + Name);
            int number = 0;
            do
            {
                Int32.TryParse(Console.ReadLine(), out number);
                if (number > 10 || number < 1)
                    Console.WriteLine("Please input numbers between 1 to 10");
            } while (number > 10 || number < 1);
            
                for (int i = 0; i < number; i++)
                    Console.WriteLine("" + Name);
            Console.ReadKey();
