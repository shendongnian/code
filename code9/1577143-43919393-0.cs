    		Console.WriteLine("type string to search");
        string searchForThis = Console.ReadLine();
        var PiClass = new PiClass();
        double.TryParse(PiClass.CalculatePi(3), out double pi);
        string piString = pi.ToString();
    	int location = piString.IndexOf(searchForThis);
        if (location >=0)
        {
            Console.WriteLine("Located  at index: " + location.ToString());
        }
        else
        {
            Console.WriteLine("Please expend search");
        }
        Console.Read();
