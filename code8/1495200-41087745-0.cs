	public class PropHelper
	{
		public PropertyInfo PropInfo {get;set;}
		public Func<object, object> Getter {get;set;}
	}
	
	private static readonly ConcurrentDictionary<Type, IEnumerable<PropHelper>> s_cachedPropHelpers = new ConcurrentDictionary<Type, IEnumerable<PropHelper>>();
	
	public static IEnumerable<PropHelper> GetPropHelpers(Type type)
	{
		return s_cachedPropHelpers.GetOrAdd(type, t => 
			{
				var props = t.GetProperties();
				var result = new List<PropHelper>();
				var parameter = Expression.Parameter(typeof(object));
				foreach(var prop in props)
				{
					result.Add(new PropHelper
						{
							PropInfo = prop,
							Getter = Expression.Lambda<Func<object, object>>(
								Expression.Convert(
									Expression.MakeMemberAccess(
										Expression.Convert(parameter, t),
										prop), 
									typeof(object)),
								parameter).Compile(),
						});
				}
				return result;
			});
	}
	
	private static Action<DataTable, IEnumerable<T>> GetAction<T>() 
	{
		return (dataTable, list) => {
			var props = GetPropHelpers(typeof(T));
			
			foreach(var prop in props)
				dataTable.Columns.Add(prop.PropInfo.Name, prop.PropInfo.PropertyType);
			
			foreach (var item in list) 
			{
				var dr = dataTable.NewRow();
				foreach(var prop in props)
					dr[prop.PropInfo.Name] = prop.Getter(item);
    			dataTable.Rows.Add(dr);
			}
		};
	}
