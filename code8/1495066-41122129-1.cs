      int numRows = data.Count() + (IncludeHeaders ?  1 : 0);
      object[,] ret = new object[numRows, 3];
      // ..
    }
    
    //// Entity Class
    public class MyTable
    {
    	public string CompanyName { get; set; }
    	public decimal Amount { get; set; }
    	public DateTime? Date { get; set; } // varchar, really?
    	public string AggCode { get; set; }
    	public string Level1 { get; set; }
    	//...
    	public string Level5 { get; set; }
    	// ...
    	public string Level20 { get; set; }
    }
