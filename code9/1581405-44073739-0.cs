    using System;
    using S22.Pop3;
    
    namespace Test {
    	class Program {
    		static void Main(string[] args) {
    			/* connect on port 995 using SSL */
    			using (Pop3Client Client = new Pop3Client("pop.gmail.com", 995, true))
    			{
    				Console.WriteLine("We are connected!");
    			}
    		}
    	}
    }
