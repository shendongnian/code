    decimal d = 4848484.000000M;
    		if((d % 1) == 0)
    		{
             // prints 4848484.00
    		  Console.WriteLine(decimal.Round(d, 2, MidpointRounding.AwayFromZero)); 
    		}
    		else
    		{
    			Console.WriteLine(d.ToString());
    		}
