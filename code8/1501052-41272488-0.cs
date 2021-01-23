    [Serializable()]
    public class Production
    {
        public Year() Years {get;set;}
    }
    [Serializable()]
    public class Year
    {
    	public int YearNumber {get;set;}
    	
    	public int SomeData1 {get;set;}
    	
    	public int SomeData2 {get;set;}
    	
    	public Month() Months {get;set;}
    }
    
    [Serializable()]
    public class Month
    {
    	public int MonthNumber {get;set;}
    	
    	public int SomeData1 {get;set;}
    	
    	public int SomeData2 {get;set}
    	
    	public Month()
    	{
    		// Default value for data - Although integer variables already default to 0,
    		// so there is no need to do this explicitly
    		this.SomeData1 = 0
    		this.SomeData2 = 0
    	}
    }
