    static void Main(string[] args)
    {
        List<Boeing737> boeings = new List<Boeing737>();
        String input;
        while (true)
        {
            Consol.WriteLine("Enter name:");
            input = Console.ReadLine();
            if (input.ToLowerInvariant() == "stop")
                break;
            String name = input.Trim();
            Consol.WriteLine("Enter fuel:");
            input = Console.ReadLine();
            if (input.ToLowerInvariant() == "stop")
                break;
            Int32 fuel;
         
            try
            {
                fuel = Int32.Parse(input.Trim());
            }
            catch
            {
                Console.WriteLine("Wrong input, stopping!");
                break;
            }
            boeings.Add(new Boeing737(name, fuel));
        }
    }
