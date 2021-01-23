    using System;
 
    class Methodcalling {
    	
    	public void Values(int num1, int num2) {
    
    		if (num1 > num2)
    		{
    			Console.WriteLine("num2 is large ");
    		}
    		else
    		{
    			Console.WriteLine("num1 is big");
    		}
    	} 
    
    	static void Main(string[] args) {
    			int a, b;
    			Methodcalling m = new Methodcalling();
    		
    			Console.WriteLine("enter a no.:");
    			a = Convert.ToInt32(Console.ReadLine());
    			Console.WriteLine("enter a no.:");
    			b = Convert.ToInt32(Console.ReadLine());
    		
    			m.Values(a, b);
    
    	}
    	
    }
