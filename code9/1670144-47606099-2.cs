    	static double RoundToHalfesOrFulls(double input)
    	{
            int asInt = (int)Math.Floor(input);
            double remainder = input-asInt;
    
            if(remainder < 0.5)
             	return asInt+0.5;
    
            return asInt+1.0;
      	} 
    
    	public static void Main()
    	{
    		for(int i= 12700; i < 12800; i+=5)
    			System.Console.WriteLine(string.Format("{0} = {1}",i/100.0, RoundToHalfesOrFulls(i/100.0)));
    	}
    }
