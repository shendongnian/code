    void Main()
    {
    	List<Word> Words = new List<UserQuery.Word> { new Word { CategoryNumber = 0, EnglishName = "WORD1" }, new Word { CategoryNumber = 1, EnglishName = "WORD2" }, new Word { CategoryNumber = 1, EnglishName = "WORD3" } };
    
    	Dictionary<CategoryTypes, List<Word>> categoryWords = Words.GroupBy(word => word.CategoryNumber).ToDictionary(x => (CategoryTypes)x.Key, x => x.ToList());
    
    	if (categoryWords.ContainsKey(CategoryTypes.Category2))
        {
    		List<Word> words = categoryWords[CategoryTypes.Category2];
    
    		for (int i = 0; i < words.Count; i++)
    		{
    			Console.WriteLine(words[i].EnglishName);
    		}
    	}
    }
    
    class Word
    {
    	public int CategoryNumber { get; set; }
    	public string EnglishName { get; set; }
    }
    
    enum CategoryTypes
    {
    	Category1 = 0,
    	Category2 = 1
    }
