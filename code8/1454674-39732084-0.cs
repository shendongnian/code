    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static Random rand = new Random();
    
    		// see https://msdn.microsoft.com/en-us/library/bb338049(v=vs.110).aspx for Distinct()
    		public class Product
    		{
    			public string Name { get; set; }
    			public int Number { get; set; }
    		}
    
    		// Custom comparer for the Product class
    		class ProductComparer : IEqualityComparer<Product>
    		{
    			// Products are equal if their names and product numbers are equal.
    			public bool Equals(Product x, Product y)
    			{
    
    				//Check whether the compared objects reference the same data.
    				if (Object.ReferenceEquals(x, y)) return true;
    
    				//Check whether any of the compared objects is null.
    				if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
    					return false;
    
    				//Check whether the products' properties are equal.
    				return x.Number == y.Number && x.Name == y.Name;
    			}
    
    			// If Equals() returns true for a pair of objects 
    			// then GetHashCode() must return the same value for these objects.
    
    			public int GetHashCode(Product product)
    			{
    				//Check whether the object is null
    				if (Object.ReferenceEquals(product, null)) return 0;
    
    				//Get hash code for the Name field if it is not null.
    				int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();
    
    				//Get hash code for the Code field.
    				int hashProductCode = product.Number.GetHashCode();
    
    				//Calculate the hash code for the product.
    				return hashProductName ^ hashProductCode;
    			}
    
    		}
    
    		static string RandomLetter()
    		{
    			return (rand.Next((int)'A', (int)'Z' + 1)).ToString();
    		}
    
    		static List<Product> CreateTestData()
    		{
    			int nItems = 20000;
    			List<Product> data = new List<Product>(nItems);
    			for (int i = 1; i <= nItems; i++)
    			{
    				data.Add(new Product { Name = RandomLetter() + RandomLetter(), Number = i % 10 });
    			}
    
    			return data;
    		}
    
    		static void Main(string[] args)
    		{
    			var list1 = CreateTestData();
    			Stopwatch sw = new Stopwatch();
    			sw.Start();
    			List<Product> noduplicates = list1.Distinct(new ProductComparer()).ToList();
    			sw.Stop();
    			Console.WriteLine($"x items: {list1.Count()} no duplicates: {noduplicates.Count()} Time: {sw.ElapsedMilliseconds} ms");
    
    			List<Product> list2 = new List<Product>();
    			if (list1 != null)
    			{
    				sw.Restart();
    				foreach (var item in list1)
    				{
    					if (!list2.Any(x => x.Name == item.Name && x.Number == item.Number))
    					{
    						list2.Add(item);
    					}
    				}
    				sw.Stop();
    				Console.WriteLine($"x items: {list1.Count()} list2: {noduplicates.Count()} Time: {sw.ElapsedMilliseconds} ms");
    			}
    
    			Console.ReadLine();
    
    		}
    	}
    }
    
