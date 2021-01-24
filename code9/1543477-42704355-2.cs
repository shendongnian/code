    using System;
    using System.Text.RegularExpressions;
    
    namespace RegVer {
    	class Prog {
    		static void Main() {
    			var verstring = "ver:1:9.5";
    			var VerABC = Regex.Matches(verstring, @"\d");
    			Console.WriteLine("a = " + VerABC[0] + "\n" +
    							  "b = " + VerABC[1] + "\n" +
    							  "c = " + VerABC[2]);
    		}
    	}
    }
