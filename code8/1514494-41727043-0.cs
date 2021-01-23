    /// <summary>
	/// CollectionContainsAnyConstraint is used to test whether a collection
	/// contains any member in expected collection.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class CollectionContainsAnyConstraint<T> : CollectionContainsConstraint
	{
		public CollectionContainsAnyConstraint(IEnumerable<T> expected) : base(expected)
		{
		}
		public override string Description
			=> Regex.Replace(base.Description, @"^\s*collection containing", "collection containing any of");
		/// <summary>
		/// Test whether any member in expected collection is available in actual collection
		/// </summary>
		/// <param name="actual">Actual collection</param>
		/// <returns></returns>
		protected override bool Matches(IEnumerable actual)
		{
			var convertedExpected = (IEnumerable<T>)Expected;
			var convertedActual = EnsureHasSameGenericType(actual, typeof(T));
			return convertedActual.Any(x => convertedExpected.Contains(x));
		}
		private IEnumerable<T> EnsureHasSameGenericType(IEnumerable actual, Type expectedType)
		{
			var sourceType = actual.GetType();
			var sourceGeneric = sourceType.IsArray
				? sourceType.GetElementType()
				: sourceType.GetGenericArguments().FirstOrDefault();
			if (sourceGeneric == null)
				throw new ArgumentException("The actual collection must contain valid generic argument");
			if (!sourceGeneric.Equals(expectedType))
				throw new ArgumentException($"The actual is collection of {sourceGeneric.Name} but the expected is collection of {expectedType.Name}");
			return (IEnumerable<T>)actual;
		}
	}
	public static class ConstraintExtensions
	{
		/// <summary>
		/// Returns a new <see cref="CollectionContainsAnyConstraint{T}"/> checking for the
		/// presence of any object of the <see cref="expected"/> collection against actual collection.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expression"></param>
		/// <param name="expected">A collection where one of its member is available in actual collection</param>
		/// <returns></returns>
		public static CollectionContainsAnyConstraint<T> ContainsAny<T>(this ConstraintExpression expression,
			params T[] expected)
		{
			var constraint = new CollectionContainsAnyConstraint<T>(expected);
			expression.Append(constraint);
			return constraint;
		}
	}
