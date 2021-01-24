	namespace System.Linq
	{
		public static class MyLinqExtensions
		{
			public static IEnumerable<T> Range<T>(this IEnumerable<T> input, int start, int end)
			{				
				int i = 0;
				foreach(var item in input)
				{
					if(i < start) continue;
					if(i > end) break;
					
					yield return item;
                    i++;
				}
			}
		}
	}
