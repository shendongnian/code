    using System;
					
    public class Program
    {
    	public static void Main()
    	{		
    		string txtLocation = "Mrs Andrews,Eaaaaa 13 Oaawood Rd ABBANVALA 3021 VIC Australia";        
    		string fullAddress = txtLocation.Substring(txtLocation.IndexOf(',') + 1);
    		fullAddress =  fullAddress.Substring(fullAddress.IndexOf(' '));
    		Console.WriteLine(fullAddress);
    	}	
    }
