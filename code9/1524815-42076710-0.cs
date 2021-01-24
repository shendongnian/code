    void Main()
    {
	       List<CCOPTG> list = new List<CCOPTG>();
	
	      for (DateTime i =DateTime.Today.AddDays(-20); i <DateTime.Today; i=i.AddDays(1))
	      {
		    list.Add(new CCOPTG { TG003 = i.ToShortDateString()});
	      }
	
	    listrecentCCOPTG( list);
    }
    public class CCOPTG
    {
	public string TG003 { get; set;}
	
    }
    // Define other methods and classes here
    public static void listrecentCCOPTG(List<CCOPTG> list)
    {
	DateTime startdate = DateTime.Today.AddDays(-7);
	DateTime enddate = DateTime.Now;
	 list.Where
		(p => DateTime.Parse(p.TG003) >= startdate && DateTime.Parse(p.TG003) <= enddate)
		.OrderByDescending(p => p.TG003).ToList().Dump();
    }
