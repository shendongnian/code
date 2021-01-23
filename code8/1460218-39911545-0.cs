    class Program
    {
        enum Choice { Volume, Area}
        static void Main(string[] args)
        {
            string input;
            Choice choice;
            do
            {
                Console.WriteLine("1. Volume");
                Console.WriteLine("2. Area");
                Console.Write("Please make your choice: ");
                input = Console.ReadLine();
            } while (!Enum.TryParse(input, out choice));
            Console.WriteLine(choice);
            switch (choice)
            {
                case Choice.Volume:
                    // calculate volume
                    break;
                case Choice.Area:
                    // calculate area
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
