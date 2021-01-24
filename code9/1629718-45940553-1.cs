    void Main()
    {
    	var data = new List<Record>
    	{
    		new Record(){Id=1, Value=1, Date=new DateTime(2017,1,1)},
    		new Record(){Id=1, Value=2, Date=new DateTime(2017,2,1)},
    		new Record(){Id=1, Value=3, Date=new DateTime(2017,3,1)},
    		new Record(){Id=2, Value=5, Date=new DateTime(2017,1,1)},
    		new Record(){Id=2, Value=6, Date=new DateTime(2017,2,1)},
    	};
    
    
	    var query = data.GroupBy(d => d.Id)
					    .SelectMany(g => g.OrderByDescending(d => d.Date)
									      .Take(1));
    	query.Dump();
    }
    
    public class Record
    {
    	public int Id { get; set; }
    	public int Value { get; set; }
    	public DateTime Date { get; set; }
    }
