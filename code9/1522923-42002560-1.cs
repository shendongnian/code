    using System;
    using System.Collections.Generic;
            					
            public class Program
            {
            	public static void Main()
            	{
            		var list = new List<int>();
            		
            		list.Add(1);
            		list.Add(2);
            		list.Add(3);
            		list.Add(4);
            		list.Add(5);
            		
            		int n = 4;
            		
            		var rand = new Random();
            		
            		var randomObjects = new List<int>();
            		
            		for (int i = 0; i<n; i++)
            		{
            			var index = rand.Next(list.Count);
            			
            			randomObjects.Add(list[index]);
            		}		
            		
            	}
            }
