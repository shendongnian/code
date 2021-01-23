	string mate = "mate";
	Console.WriteLine($"How many countries you want {mate}?");
	string numberOfCountries = Console.ReadLine();
	int numberOfCountriesInt;
	while ( !int.TryParse( numberOfCountries, out numberOfCountriesInt ) )
	{
		mate = mate.Insert(1, "a");
		Console.WriteLine($"How many countries you want {mate}?");
		numberOfCountries = Console.ReadLine();
		
	}
	Console.WriteLine("Please name your countries ");
	string[] namesOfCountries = new string[numberOfCountriesInt];
	for (int i = 0; i < namesOfCountries.Length; i++)
	{
		namesOfCountries[i] = Console.ReadLine();
	}
	for (int i = 0; i < namesOfCountries.Length; i++)
	{
		Console.WriteLine($"{i+1}, {namesOfCountries[i]}");
	}
