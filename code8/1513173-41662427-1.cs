        using System;
        using System.Collections.Generic;
        					
        public class Program
        {
        	public static void Main()
        	{
        		var list = new List<int>();        		
        		var rand = new Random();
        		
        		while(list.Count <10)
        		{
        			var number = rand.Next(1,20);
        			
        			if(! list.Contains(number))
        				list.Add(number);    			
        		}
        		
        		foreach(var item in list)    		
        			Console.WriteLine(item);  
        	}
        }
