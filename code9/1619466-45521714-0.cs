    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    namespace Main {
    	public struct ParsedData {
    		public string IP { get; set; }
    		public string Port { get; set; }
    		public string Username { get; set; }
    		public string Password { get; set; } 
    	}
    	class Prog {
    		static List<ParsedData> pdl = new List<ParsedData>();
    		static string file = @"12.23.425.56:90:kukur:psiar%4
    151.23.255.52:3131:Zandga:Ikurit
    52.23.45.56:5125:Ningame:Mirsga!@
    112.223.45.56:4000:Bisgo:One0ne";
    		static void Main() {
    			var re = new Regex(@"(.+?):(.+?):(.+?):(.+)");
    			foreach (Match m in re.Matches(file)) {
    				pdl.Add(new ParsedData() { IP = m.Groups[1].Value, Port = m.Groups[2].Value, Username = m.Groups[3].Value, Password = m.Groups[4].Value });
    				Console.WriteLine("IP: " + m.Groups[1] + " PORT: " + m.Groups[2] + " USR_NM: " + m.Groups[3] + " PASS: " + m.Groups[4]);
    			}
    		}
    	}
    }
