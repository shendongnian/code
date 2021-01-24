    using System;
    using System.Linq;
					
    public static void Main()
	{
		string[] capitals = new string[] { "Athens", "Bangkok", "Beijing", "Berlin", "Amsterdam", "Ankara" };
        string[] countrynames = new string[] { "Greece", "Thailand", "China", "Germany", "Netherlands", "Turkey" };
        var rand = new Random().Next(0, capitals.length); // assuming it can be more than 5
		string randomCapital = capitals[rand];
		var correspondingRandomCountry = countrynames[rand]; // assuming your country array is in the righ order
        Console.WriteLine("Which country has the capital city {0}? ", randomCapital);
        Console.WriteLine("Enter up to 3 names, comma-seperated: ");
        string userinput = Console.ReadLine();
        string[] temp = userinput.Split(',');
		
		Console.WriteLine(temp.Any(t => t.ToLower().Equals(correspondingRandomCountry.ToLower())) == true ? "right answer" : "wrong answer");
		
		
	}
