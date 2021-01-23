	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> Recursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childSelector, Func<T, bool> condition = null)
		{
			foreach (T item in source)
			{
				bool shouldAdd = true;
				if (condition != null)
				{
					bool matched = condition(item);
					if (!matched) shouldAdd = false;
				}
				if(shouldAdd)  yield return item;
				IEnumerable<T> childEnumerable = childSelector(item);
				if (childEnumerable != null && childEnumerable.Any())
				{
					// Call recursive
					IEnumerable<T> childsMatching = childEnumerable.Recursive(childSelector, condition);
					if (childsMatching != null && childsMatching.Any())
					{
						foreach (T childMatch in childsMatching)
						{
							yield return childMatch;
						}
					}
				}
			}
		}
	}
