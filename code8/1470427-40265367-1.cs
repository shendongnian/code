    public class AssociativeArray
	{
		private dynamic _data = new ExpandoObject();
		public object this[params string[] keys]
		{
			get
			{
				dynamic lastObject = _data;
				foreach (var key in keys.Take(keys.Count() - 1))
				{
					var dic = lastObject as IDictionary<string, Object>;
					lastObject = dic[key] as ExpandoObject;
				}
				return (lastObject as IDictionary<string, object>)[keys.Last()];
			}
			set
			{
				dynamic lastObject = _data;
				foreach (var key in keys.Take(keys.Count() - 1))
				{
					var dic = lastObject as IDictionary<string, Object>;
					dic.Add(key, new ExpandoObject());
					lastObject = dic[key];
				}
				(lastObject as IDictionary<string, object>).Add(keys.Last(), value);
			}
		}
	}
