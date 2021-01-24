    void Main()
    {
    	List<Page> PageStatistics = new List<UserQuery.Page>();
    	
    	PageStatistics.Add(new Page(new DateTime(2018,02,12),3));
    	PageStatistics.Add(new Page(new DateTime(2018,02,12),32));
    	PageStatistics.Add(new Page(new DateTime(2018,02,11),20));
    	PageStatistics.Add(new Page(new DateTime(2018,02,11),44));
    	PageStatistics.Add(new Page(new DateTime(2018,02,11),20));
    	PageStatistics.Add(new Page(new DateTime(2018,02,11),2));
    	PageStatistics.Add(new Page(new DateTime(2018,02,11),1));
    	PageStatistics.Add(new Page(new DateTime(2018,02,10),22));
    	PageStatistics.Add(new Page(new DateTime(2018,02,10),2));
    	PageStatistics.Add(new Page(new DateTime(2018,02,10),20));
    	PageStatistics.Add(new Page(new DateTime(2018,02,10),10));
    	
    
    	var result  = 
    	PageStatistics.Where(x => x.Status == 1)
    	.GroupBy(x => new { Day = x.CreatedAt.Date })
    	.Select(x => new { Date = x.Key.Date.ToString("dd/MM/yyyy"), 
                           Activity = x.Sum(y => y.AppID), 
                           Record = x.Count()});
    	
    	result.Dump();
    }
    
    public class Page
    {
    	public DateTime CreatedAt { get; set; }
    	public int Status { get; set; }
    	public int AppID { get; set; }
    	
    	public Page(DateTime c, int a)
    	{
    		CreatedAt = c;
    		AppID = a;	
    		Status = 1;
    	}
    }
