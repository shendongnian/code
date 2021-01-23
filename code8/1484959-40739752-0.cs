    public class DoubleResult
    {
    	public bool IsValid { get; set;}
    	public double Result {get; set;}
    }
    
    public DoubleResult CheckValuedoubleOrNot(dynamic value)    
    {
    	double price;	
    	if (Double.TryParse(value, out price))
    	{
    		return new DoubleResult { IsValid = true, Result = price };
    	}
    	else
    	{
    		return new DoubleResult { IsValid = false };
    	}
    }
    
    listBoardData.Where(x => !CheckValuedoubleOrNot(x.FromDuration).IsValid)
