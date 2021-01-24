    public static IEnumerable<int> BatchCount(this IEnumerable<int> source)
	{
		using(var e = source.GetEnumerator())
		{
			if(!e.MoveNext())
				yield break;
	
			var lastItem = e.Current;
			int currentCount = 1;
			
			while(e.MoveNext())
			{
				if(e.Current == lastItem)
					currentCount++;
				else
				{
					yield return currentCount;
					currentCount = 1;
					lastItem = e.Current;
				}
			}
			
			yield return currentCount;
		}
	}
