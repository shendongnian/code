	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace Demo.Extensions
	{
		public static class IEnumerableExtensions
		{
			public static IEnumerable<T> Page<T>(this IEnumerable<T> queryable, int page, int pageSize)
			{
				return queryable.Skip((page - 1) * pageSize).Take(pageSize);
			}
		}
	}
