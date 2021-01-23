    public static void Main(string[] args) {
        const double largeVal = 63619141321;
			
        DateTime date = new DateTime();
        Console.WriteLine(date.ToString());
        double totalSeconds = (DateTime.Now - date).TotalSeconds;
        Console.WriteLine(totalSeconds - largeVal);
        Console.WriteLine("Press any key to continue . . . ");
        Console.ReadKey(true);
    }
