	public static int ConsoleReadInteger(string message)
	{
		Console.WriteLine(message);
		return Convert.ToInt32(Console.ReadLine());
	}
	
	public static void Main(string[] args)
	{
		int age = ConsoleReadInteger("Enter your age in years ");
		int weight = ConsoleReadInteger("Enter your weight in pounds ");
		int height = ConsoleReadInteger("Enter your height in inches ");
		int gender = ConsoleReadInteger("Gender? Enter male/female (1 for Male, 2 for Female) ");
		Console.WriteLine("To calculate your daily calories allowed, please select your level of exercise activity");
		Console.WriteLine("1. You don't exercise"); // bmr x 1.2
		Console.WriteLine("2. You engage in light exercise one to three days a week"); // bmr x 1.375
		Console.WriteLine("3. You exercise moderately three to five times a week"); // bmr x 1.55
		Console.WriteLine("4. You exercise intensely six to seven days a week"); // bmr x 1.725
		Console.WriteLine("5. you exercise intensely six to seven days a week and have a physically active job"); // bmr x 1.9      
		Dictionary<int, double> exerciseFactors = new Dictionary<int, double>()
		{
			{ 1, 1.2 }, { 2, 1.375 }, { 3, 1.55 }, { 4, 1.725 }, { 5, 1.9 },
		};
		double exerciseFactor = exerciseFactors[Convert.ToInt32(Console.ReadLine())];
		Console.WriteLine("Age: " + age);
		Console.WriteLine("Height: " + height);
		Console.WriteLine("Weight: " + weight);
		Console.WriteLine("Gender: " + (gender == 1 ? "Male" : "Female"));
		
		double bmr =
			gender == 1
			? 66 + (6.23 * weight) + (12.7 * height) - (6.8 * age)
			: 655 + (4.35 * weight) + (4.7 * height) - (4.7 * age);
		double caloriesAllowed = bmr * exerciseFactor;
		
		Console.WriteLine("Your BMR is: " + bmr);
		Console.WriteLine("Your daily calories allowed is " + caloriesAllowed);
		string response = "YES";
		while (response == "YES")
		{
			caloriesAllowed -= ConsoleReadInteger("Enter the amount of calories consumed: ");
			Console.WriteLine("Your remaining calories allowed is " + caloriesAllowed);
			Console.WriteLine("Do you want to continue? (YES / NO)");
			response = Console.ReadLine().ToUpperInvariant();
		}
	}
