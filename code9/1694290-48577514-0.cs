    using System;
    using System.Linq;
    
    public class Program1
    {
    	public static void Main()
    	{
    		var mydata = new[] {"1,3,4,5,1,3,a,s,r,3", "2, 4 , a", " 2,3,as"};
    		
            // function that checks it- perfoms not as good as reges as internal stringarray
            // is build and analyzed
    		Func<string,bool> isValid = 
    			data => data.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries)
    			.Select(s => s.Trim())
    			.All(aChar => aChar.Length == 1 && char.IsLetterOrDigit(aChar[0]));
    		
    		foreach (var d in mydata)
    		{
    			
    			Console.WriteLine(string.Format("{0} => is {1}",d, isValid(d) ? "Valid" : "Invalid"));
    		}
    	}
    } 
