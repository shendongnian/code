    using System;   
	class Test { 
		static void Main()  { 
			try{ 
				int a=10,b=0,c=0;c=a/b ; 
				Console.WriteLine(c);
			}   
			catch(System.Exception e) 
            when (!(e is DivideByZeroException)){ 
				Console.WriteLine(e.Message); 
			} 
			catch(System.DivideByZeroException ex) {  
				Console.WriteLine(ex.Message); 
			} 
		} 
	}
