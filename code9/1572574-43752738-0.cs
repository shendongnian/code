    class Program
    {
        static void Main()
        {
            //read from console
            string userInput = Console.ReadLine();
            //treat read value
            switch(userInput)
            {
                case "Y":
                    Console.WriteLine("Y was entered!");
                    break;
                case "N":
                    Console.WriteLine("N was entered!");
                    break;
            }
        }
    }
