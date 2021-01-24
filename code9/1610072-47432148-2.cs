    public async Task<int> SeedBookEntitiesFromJson(string filePath)
    {
    	if (string.IsNullOrWhiteSpace(filePath))
    	{
    		throw new ArgumentException($"Value of {filePath} must be supplied to {nameof(SeedBookEntitiesFromJson)}");
    	}
    	if (!File.Exists(filePath))
    	{
    		throw new ArgumentException($"The file { filePath} does not exist");
    	}
    	var dataSet = File.ReadAllText(filePath);
    	var seedData = JsonConvert.DeserializeObject<List<Book>>(dataSet);
    
    	// ensure that we only get the distinct books (based on their name)
    	var distinctSeedData = seedData.GroupBy(b => b.BookName).Select(b => b.First());
    
    	_context.Books.AddRange(distinctSeedData);
    	return await _context.SaveChangesAsync();
    }
