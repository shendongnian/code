    using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			List<string> list1 =new List<string>();
			list1.Add("text 1");
			list1.Add("text 2");
			list1.Add("text 3");
			
			List<string> list2 =new List<string>();
			list2.Add("text 4");
			list2.Add("text 1");
			list2.Add("text 2");
			list2.Add("text 5");
			
			List<string> list3 = list1.Union(list2).ToList();
			foreach(string item in list3){
				Console.WriteLine(item);
			}
		}
	}
