	void Main()
	{
		var data1 = new[] {
				  new { Product = "Product 1", Year = 2009, Sales = 1212 },
				  new { Product = "Product 2", Year = 2009, Sales = 522 },
				  new { Product = "Product 1", Year = 2010, Sales = 1337 },
				  new { Product = "Product 2", Year = 2011, Sales = 711 },
				  new { Product = "Product 2", Year = 2012, Sales = 2245 },
				  new { Product = "Product 3", Year = 2012, Sales = 1000 }
			  };
		string jsondata = JsonConvert.SerializeObject(data1).Dump();
		
		// we have to create a type for deserialization
		var ob = new { Product = "Product 1", Year = 2009, Sales = 1212 };
		var ltype = typeof(List<>);
		var constructed = ltype.MakeGenericType(new[] {ob.GetType()});
		
		// deserializing
		var deserialized = (JsonConvert.DeserializeObject(jsondata, constructed) as IList).Cast(ob);	
	}
	
	public static class Ext
	{
		public static IEnumerable<T> Cast<T>(this IEnumerable x, T typeHolder)
		{
			foreach (var item in x)
			{
				yield return (T)item;
			}
		}
	}
