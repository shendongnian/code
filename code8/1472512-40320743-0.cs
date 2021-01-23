	static void Main(string []args) {
		Console.WriteLine("Enter first number: ");
		var Number1 = double.Parse(Console.ReadLine());
		Console.WriteLine("Enter second number: ");
		var Number2 = double.Parse(Console.ReadLine());
		double result = Number1 / Number2;
		Console.WriteLine("{0} divided by {1} is {2}", Number1, Number2, result);
	}
