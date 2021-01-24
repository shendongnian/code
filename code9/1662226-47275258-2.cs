    void Main()
    {
    	var data = new List<Info>
    	{
    		new Info(){ Book=1, Chapter=1, Paragraph=1, TimesRead=3},
    		new Info(){ Book=1, Chapter=1, Paragraph=2, TimesRead=3},
    		new Info(){ Book=1, Chapter=1, Paragraph=3, TimesRead=4},
    		new Info(){ Book=1, Chapter=2, Paragraph=1, TimesRead=5},
    		new Info(){ Book=1, Chapter=2, Paragraph=2, TimesRead=2},
    		new Info(){ Book=1, Chapter=2, Paragraph=3, TimesRead=2},
    		new Info(){ Book=1, Chapter=2, Paragraph=4, TimesRead=9},
    		new Info(){ Book=2, Chapter=1, Paragraph=1, TimesRead=3},
    	};
    
    	var query = data.GroupBy(d => new {Book = d.Book, Chapter = d.Chapter})
    	.Select(g => new
    	{
    		Book = g.Key.Book,
    		Chapter = g.Key.Chapter,
    		TimesRead = g.Min(d => d.TimesRead)
    	});
    
    	query.Dump();
    }
    
    public class Info
    {
    	public int Book { get; set; }
    	public int Chapter { get; set; }
    	public int Paragraph { get; set; }
    	public int TimesRead { get; set; }
    }
