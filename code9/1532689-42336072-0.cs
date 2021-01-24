    using System;
    using System.Linq;
					
    public class Program
    {
	    public static void Main()
	    {
		    var input = "Hello world".ToCharArray();
		    var vowels = "aeiouAEIOU".ToCharArray();
		    
            input.Where(c=>vowels.Contains(c)).ToList().ForEach(v=>Console.WriteLine("[Server] Vowel characters deteced: " + v));	
     	}
    }
