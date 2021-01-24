    using System;
    using System.Linq; // Add the Linq referece
    					
    public class Program
    {
    	public static void Main()
    	{
    		string str = "Wordpress, MVC, AngularJS, MVC, CSharp, Wordpress, MVC, AngularJS, MVC, CSharp";
            string[] strT = str.Replace(" ", string.Empty).Split(',');
    		strT = strT.Distinct().ToArray();
            foreach (var poo in strT)
    
            {
    			Console.WriteLine(string.Format("<button type='button' class='md-button md-warn {0}'>{0}</button>", poo.ToLower().Trim()));
            }
    		
    	}
    }
