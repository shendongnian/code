	using System;
	using System.Linq;
	using System.Collections.Generic;
	
	public class Program
	{
		public static void Main()
		{
			var myList = (new []{1 ,2, 3, 4}).ToList();
			var newList =  new List<ListObject>();
			var count = myList.Count;
			for (int i = 0; i < count - 1; i++)
			{		  
				for(int j = i + 1; j < count; j++)
				{	
					   newList.Add(new ListObject(){ I = myList[i], J = myList[j]});
				}
			}
			newList.ForEach(x =>  Console.WriteLine(x));
		}
		
		class ListObject
		{
			public int I {get; set;}
			public int J {get; set;}
			
			public override string ToString()
			{
				return I + " - " + J;
			}
		}
	}
