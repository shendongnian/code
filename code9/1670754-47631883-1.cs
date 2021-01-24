	public static void Main()
	{
		var sampleData = new List<Animal>
		{
			new Animal(false, AnimalSize.Small),
			new Animal(false, AnimalSize.Large),
			new Animal(false, AnimalSize.Medium)
		};
		AnimalSize[] customSortOrder = new[]
    	{
			AnimalSize.Small,
			AnimalSize.Medium,
			AnimalSize.Large
		};
		
		var results = sampleData.OrderBy( a => Array.IndexOf(customSortOrder, a.Size ));
		
		foreach (var a in results)
		{
			Console.WriteLine(a.Size);
		}
