	public static class Ext
	{
		public static IEnumerable<T> Deserialize<T>(this string source, T typeHolder)
		{
			var ltype = typeof(List<>);
			var constructed = ltype.MakeGenericType(new[] { typeHolder.GetType() });
	
			// deserializing
			return (JsonConvert.DeserializeObject(source, constructed) as IList).Cast(typeHolder);
		}
	
		public static IEnumerable<T> Cast<T>(this IEnumerable x, T typeHolder)
		{
			foreach (var item in x)
			{
				yield return (T)item;
			}
		}
	}
