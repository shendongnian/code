	public enum FilterType
	{
		None,
		Less,
		LessOrEquals,
		Equals,
		Greater,
		GreaterOrEquals,
	}
	[AttributeUsage( AttributeTargets.Property, Inherited = false, AllowMultiple = false )]
	sealed class FilterAttribute : Attribute
	{
		public string PropName { get; }
		public FilterType FilterType { get; }
		public FilterAttribute() : this( null, FilterType.Equals )
		{
		}
		public FilterAttribute( FilterType filterType ) : this( null, filterType )
		{
		}
		public FilterAttribute( string propName, FilterType filterType )
		{
			PropName = propName;
			FilterType = filterType;
		}
	}
	public interface IFilterParams<T>
	{
	}
	public static class Extensions
	{
		public static IEnumerable<T> Filter<T>( this IEnumerable<T> source, IFilterParams<T> filterParams )
		{
			var sourceProps = typeof( T ).GetProperties();
			var filterProps = filterParams.GetType().GetProperties();
			foreach ( var prop in filterProps )
			{
				var filterAttr = prop.GetCustomAttribute<FilterAttribute>();
				if ( filterAttr == null )
					continue;
				object val = prop.GetValue( filterParams );
				if ( val == null )
					continue;
				// oops.. little hole..
				if ( prop.PropertyType == typeof( string ) && (string)val == string.Empty )
					continue;
				string propName = string.IsNullOrEmpty( filterAttr.PropName )
					? prop.Name
					: filterAttr.PropName;
				if ( !sourceProps.Any( x => x.Name == propName ) )
					continue;
				Func<T, bool> filter = CreateFilter<T>( propName, filterAttr.FilterType, val );
				source = source.Where( filter );
			}
			return source;
		}
		private static Func<T, bool> CreateFilter<T>( string propName, FilterType filterType, object val )
		{
			var item = Expression.Parameter( typeof( T ), "x" );
			var propEx = Expression.Property( item, propName );
			var valEx = Expression.Constant( val );
			Expression compareEx = null;
			switch ( filterType )
			{
				case FilterType.LessOrEquals:
					compareEx = Expression.LessThanOrEqual( propEx, valEx );
					break;
				case FilterType.Less:
					compareEx = Expression.LessThan( propEx, valEx );
					break;
				case FilterType.Equals:
					compareEx = Expression.Equal( propEx, valEx );
					break;
				case FilterType.Greater:
					compareEx = Expression.GreaterThan( propEx, valEx );
					break;
				case FilterType.GreaterOrEquals:
					compareEx = Expression.GreaterThanOrEqual( propEx, valEx );
					break;
				default:
					throw new Exception( $"Unknown FilterType '{filterType}' on property '{propName}'!" );
			}
			var lambda = Expression.Lambda<Func<T, bool>>( compareEx, item );
			Func<T, bool> filter = lambda.Compile();
			return filter;
		}
	}
