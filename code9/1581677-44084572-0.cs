	public class Tables
	{
		public int Age { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }
	}
	
	public class Matcher
	{
		private static readonly PropertyInfo[] Properties = typeof(Tables).GetRuntimeProperties().ToArray();
		
		public IQueryable<Tables> FilterResult(string search, List<Tables> dtResult)
		{	
			if(search == null) //Consider using string.IsNullOrWhiteSpace(search) but I wasn't sure if you want to avoid searching for spaces
			{
				return dtResult.AsQueryable();
			}
			return dtResult.Where(p => IsMatch(p, search)).AsQueryable();
		}
	
		private static bool IsMatch(Tables tables, string search)
		{
			foreach (var propertyInfo in Properties)
			{
				var value = propertyInfo.GetValue(tables);
				if (value != null && value.ToString().Contains(search))
				{
					return true;
				}
			}
	
			return false;
		}
	}
