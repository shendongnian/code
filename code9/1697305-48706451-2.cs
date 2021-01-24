    void Main()
    {
       OrderNumberGenerator orderNumberGenerator = new OrderNumberGenerator();
    
       Debug.WriteLine(orderNumberGenerator.Next());
       Debug.WriteLine(orderNumberGenerator.Next());
    }
    
    // Define other methods and classes here
    public class OrderNumberGenerator
    {
        long orderPart1 = 100000;
    	int orderPart2 = 1000;
    	
    	public string Next()
    	{
    		if(orderPart2 == 9999)
    		{
    			orderPart1++;
    			orderPart2 = 1000;
    		}
    		else
    		{
    			orderPart2++;
    		}
    		
    		return string.Format("JI-{0}-{1}", orderPart1, orderPart2);
    	}
    }
