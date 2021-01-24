	using System;
	using System.Collections.Generic;
	class Item
	{
		internal string Name { get; set; }
		internal short Age { get; set; }
		internal string City { get; set; }
	}
	public static class ExtensionMethods
	{
		public static List<T> FindAll<T>(this List<T> list, List<Predicate<T>> predicates)
		{
			List<T> L = new List<T>();
			foreach (T item in list)
			{
				foreach (Predicate<T> p in predicates)
				{
					if (p(item)) L.Add(item);
				}
			}
			return L;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Item> items = new List<Item>();
			items.Add(new Item { Name = "Bob", Age = 31, City = "Denver" });
			items.Add(new Item { Name = "Mary", Age = 44, City = "LA" });
			items.Add(new Item { Name = "Sue", Age = 21, City = "Austin" });
			items.Add(new Item { Name = "Joe", Age = 55, City = "Redmond" });
			items.Add(new Item { Name = "Tom", Age = 81, City = "Portland" });
			string nameFilter = "Bob,Mary";
			//string ageFilter = "55,21";
			string ageFilter = null;
			string cityFilter = "Portland";
			List<Predicate<Item>> p = new List<Predicate<Item>>();
			if (nameFilter != null)
			{
				p.Add(i => nameFilter.Contains(i.Name));
			}
			if (cityFilter != null)
			{
				p.Add(i => cityFilter.Contains(i.City));
			}
			if (ageFilter != null)
			{
				p.Add(i => ageFilter.Contains(i.Age.ToString()));
			}
			var results = items.FindAll(p);
			foreach (var result in results)
			{
				Console.WriteLine($"{result.Name} {result.Age} {result.City}");
			}
		}
	}
