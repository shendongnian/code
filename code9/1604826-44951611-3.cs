    public static void Main(string[] args)
    {
        // declarations 
        // 12 inches to a foot
        // 36 inches to a yard
        // 63360 inches per 1 mile
        double userInput = 0; // if "0" is removed the program will not function CS0165 error
        double feet = 12;
        double yards = 36;
        double miles = 63360;
        Console.WriteLine("Please enter the number of inches to convert: ");
        userInput = Convert.ToInt32(Console.ReadLine());
        double ansFeet = userDivFeet(ref feet, ref userInput);
        double ansYards = userDivYards(ref yards, ref userInput);
        double ansMiles = userDivMiles(ref miles, ref userInput);
        // output each calculation and display with console to hold the results
        WriteLine(userInput + " inches converts into " + ansFeet + " feet.");
        WriteLine(userInput + " inches converts into " + ansYards + " yards.");
        WriteLine(userInput + " inches converts into " + ansMiles + " miles.");
        Console.ReadKey();
    }
