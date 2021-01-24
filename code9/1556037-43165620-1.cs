    static void Main(string[] args)
    {
        var filePath = "test.txt";
        // Simulated input from user 
        // these should come from entries in the application?
		var name = "Foo"; 
		var profession = "Bar";
		var personData = new PersonData(); // class declared below
    
		using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
		using (StreamReader reader = new StreamReader(fileStream))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				if (line.StartsWith("id:"))
					personData.ID = line;
			}
		} // Now reader and filestream is closed, file is available again.
		
        // You don't specify what you would like to happen if personData.ID is null, 
        // so I make an assumption the generatedId is what you'd like to use.
        if (string.IsNullOrWhiteSpace(personData.ID)
			personData.ID = $"id: {generatedId}"; 
        // Add the data from the entries
		personData.Name = $"name: {name}";
		personData.Profession = $"profession: {profession}";
		File.Delete(filePath); // remove the file
        using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
    	using (StreamWriter writer = new StreamWriter(fileStream))
    	{
    	    writer.WriteLine(personData.ID);
    		writer.WriteLine(personData.Name);
    		writer.WriteLine(personData.Profession);
    	}
    }
    private class PersonData
    {
    	public string ID { get; set; }
    	public string Name { get; set; }
    	public string Profession { get; set; }
    }
