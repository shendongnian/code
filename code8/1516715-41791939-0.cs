    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string s = "1|0|1|58|4|4|351|25|8|||1|0||6|3|1000|49|20|430|17|6|0|10|0|1200|25||30|20|20|20|20|0|100|61028|1|0|0|1|1|0|5000|40022|1|";
    		var arr = s.Split('|') ;    		
    		var retVal = String.Join("|", arr.Take(43));
    		Console.WriteLine(retVal);
    	}
    }
