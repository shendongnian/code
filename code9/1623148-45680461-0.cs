    using System;   
	class Test { 
		static void Main()  { 
			try{ 
				int a=10,b=0,c=0;c=a/b ; 
				Console.WriteLine(c);
			}   
			catch(System.DivideByZeroException ex) {  
				Console.WriteLine(ex.Message); 
			} 
			catch(System.Exception e) { 
				Console.WriteLine(e.Message); 
			} 
		} 
	}
