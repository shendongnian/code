    void Main()
    {
    	var client = new MongoClient();
    	var db = client.GetDatabase("db");
    	var col = db.GetCollection<Foo>("foos");
    	col.AsQueryable().Select(x => new Projection { Date = new Date { Year = x.Time.Year, Month = x.Time.Month, Day = x.Time.Day, Hour = x.Time.Hour } }).GroupBy(x => x.Date).Select(x => new Result { Count = x.Count(), Id = x.Key });
    }
    
    public class Foo
    {
    	public ObjectId Id {get;set;}
    	public DateTime Time {get;set;}
    	public string Bar {get;set;}
    }
    
    public class Projection
    {
    	public Date Date {get;set;}
    }
    
    public class Date
    {
    	public int Year { get; set; }
    	public int Month { get; set; }
    	public int Day { get; set; }
    	public int Hour {get;set;}
    }
    
    public class Result
    {
    	public Date Id {get;set;}
    	public int Count {get;set;}
    }
