      static void Main(string[] args)
        {
            string[] workerName = new string[100];
            var i = 0;
            do
            {
                Console.Write("Please Enter The Worker's Name: ");
                workerName[i++] = Console.ReadLine();
                Console.Write("Do You Want To Enter A Worker's Name? Y or N: ");
            } while (Console.ReadKey().Key == ConsoleKey.Y);
        }
