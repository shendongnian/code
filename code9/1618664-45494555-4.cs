	public abstract class Addition<T>
	{
		private readonly Lazy<Expression<Func<T, T, T>>> _lazyExpression;
		private readonly Lazy<Func<T, T, T>> _lazyFunc;
	
		public Func<T, T, T> Execute
		{
			get { return _lazyFunc.Value; }
		}
		public Expression<Func<T, T, T>> LinqExpression
		{
            get { return _lazyExpression.Value; }
		}
		
		protected Addition()
		{
			_lazyExpression = new Lazy<Expression<Func<T, T, T>>>(InitializeExpression);
			_lazyFunc = new Lazy<Func<T, T, T>>(() => LinqExpression.Compile());
		}
		protected abstract Expression<Func<T, T, T>> InitializeExpression();
	}
	public sealed class DefaultAddition<T> : Addition<T>
	{
		private static readonly Lazy<DefaultAddition<T>> _lazyInstance = new Lazy<DefaultAddition<T>>(() => new DefaultAddition<T>());
		public static DefaultAddition<T> Instance
		{
			get {return _lazyInstance.Value; }
		}
        // Private constructor, you only get an instance via the Instance static property
		private DefaultAddition()
		{
		}
	
		protected override Expression<Func<T, T, T>> InitializeExpression()
		{
			var paramX = Expression.Parameter(typeof(T), "x");
			var paramY = Expression.Parameter(typeof(T), "y");
			var body = Expression.Add(paramX, paramY);
			return Expression.Lambda<Func<T, T, T>>(body, paramX, paramY);
		}
	}
	public static class Operations
	{
		public static T Add<T>(T x, T y)
		{
			return DefaultAddition<T>.Instance.Execute(x, y);
		}
		public static T AddAll<T>(IEnumerable<T> enumerable)
		{
			var itemAdd = DefaultAddition<T>.Instance.Execute;
			return enumerable.Aggregate(default(T), (result, item) => itemAdd(result, item));
            
            // This might be more efficient than Aggregate, but I didn't benchmark it
            
            /*
			var result = default(T);
			foreach (var item in enumerable)
			{
				result = itemAdd(result, item);
			}
			return result;
            */
		}
	}
