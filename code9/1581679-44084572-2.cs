	public class Matcher<T>
	{
		private static readonly PropertyInfo[] Properties = typeof(T).GetRuntimeProperties().ToArray();
		
		public IQueryable<T> FilterResult(string search, List<T> items)
		{
			if ( search == null) //Consider using string.IsNullOrWhiteSpace(search) but I wasn't sure if you want to avoid searching for spaces
			{
				return items.AsQueryable();
			}
	
			return items.Where(p => IsMatch(p, search)).AsQueryable();
		}
	
		private static bool IsMatch(T item, string search)
		{
			foreach (var propertyInfo in Properties)
			{
				var value = propertyInfo.GetValue(item);
				if (value != null && value.ToString().Contains(search))
				{
					return true;
				}
			}
	
			return false;
		}
	}
