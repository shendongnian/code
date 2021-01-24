	public static class Extensions
	{
		public static Paged<T> Page<T>(this IEnumerable<T> instance, int? page = 1, int? size = 10)
		{
			var items = instance
				.Skip((page.Value - 1) * size.Value)
				.Take(size.Value)
				.ToList();
	
			return new Paged<T>()
			{
				Page = page.Value,
				Size = size.Value,
				Total = instance.Count() - 1,
				Items = items,
			};
		}
	}
