    decimal d1 = 3456786.065343M;
        		if((d1 % 1) == 0)
        		{
        		  Console.WriteLine(decimal.Round(d1, 2, MidpointRounding.AwayFromZero)); 
        		}
        		else
        		{
                    //prints 3456786.065343
        			Console.WriteLine(d1.ToString()); 
        		}
