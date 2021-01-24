    using System;
    using System.Text.RegularExpressions;
    
    namespace RegVer {
    	class Prog {
    		static void Main() {
    			var verstring = "ver:1:9.5";
    			var dotVerString = verstring.Replace(':','.');
    			Console.WriteLine(Regex.Match(dotVerString, @"ver\.([\d\.]+)").Groups[1].Value);
    		}
    	}
    }
