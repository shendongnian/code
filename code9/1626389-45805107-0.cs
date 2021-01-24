    using System;
    using System.Collections.Generic;
    
    namespace Test {
    	static class Program {
    		static void Main() {
    			List<string> list = new List<string>() {"BOT20", "BOB10", "BUG40", "BAG90"};
    			list.Sort();
    			foreach(var el in list)  {
    				Console.Write(el + ">");
    			}
    		}
    	}
    }
