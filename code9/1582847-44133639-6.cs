    static void Main(string[] args)
    {
        IQueryable<Word> allWords = new WordCollection();
        IQueryable<Word> Bwords = allWords
            .Where(word => word.Text.FirstOrDefault() == 'b')
            .Take(40);
        foreach (var word in Bwords)
        {
	        Console.WriteLine(word.Text);
        }
    }
