    void Main()
    {
    	var data = new List<DataRow>()
    	{
    		new DataRow { A = 1, B = 101, State = 1001 },
    		new DataRow { A = 2, B = 102, State = 1002 },
    		new DataRow { A = 3, B = 103, State = 1003 },
    		new DataRow { A = 4, B = 104, State = 1004 },
    	};
    
    	var searchTerms = new List<SearchData>()
    	{
    		new SearchData {B=101, State=1001},
    		new SearchData {B=103, State=1003},
    	};
    
    	var predicate = PredicateBuilder.New<DataRow>();
    	foreach (var term in searchTerms)
    	{
    		predicate = predicate.Or(p=> p.B == term.B && p.State == term.State);
    	}
    	
    	var query = data.Where(predicate);
    	
    	query.Dump();
    }
    public class DataRow
    {
    	public int A { get; set; }
    	public int B { get; set; }
    	public int State { get; set; }
    }
    
    public class SearchData
    {
    	public int B { get; set; }
    	public int State { get; set; }
    }
