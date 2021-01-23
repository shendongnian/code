	void Main()
	{
		var itemList = new List<dynamic>{ new {foo = true, bar = "a", baz = "b" }, new {foo = true, bar = "c", baz = "d" } };
		var filtered = itemList.ToAnonymousList().Where("bar = @0", "a");
		filtered.Dump();
	}
	
	public static class EnumerableEx {
		public static IList ToAnonymousList(this IEnumerable enumerable)
		{
		    var enumerator = enumerable.GetEnumerator();
		    if (!enumerator.MoveNext())
		        throw new Exception("?? No elements??");
		
		    var value = enumerator.Current;
		    var returnList = (IList) typeof (List<>)
		        .MakeGenericType(value.GetType())
		        .GetConstructor(Type.EmptyTypes)
		        .Invoke(null);
		
		    returnList.Add(value);
		
		    while (enumerator.MoveNext())
		        returnList.Add(enumerator.Current);
		
		    return returnList;
		}
	}
