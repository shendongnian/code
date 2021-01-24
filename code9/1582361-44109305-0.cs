	public static IEnumerable<TResult> MergeJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
	{
		if (outer == null)
			throw new ArgumentNullException(nameof(outer));
		if (inner == null)
			throw new ArgumentNullException(nameof(inner));
		if (outerKeySelector == null)
			throw new ArgumentNullException(nameof(outerKeySelector));
		if (innerKeySelector == null)
			throw new ArgumentNullException(nameof(innerKeySelector));
		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));
		return MergeJoinIterator(outer, inner, outerKeySelector, innerKeySelector, resultSelector, Comparer<TKey>.Default);
	}
	public static IEnumerable<TResult> MergeJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IComparer<TKey> comparer)
	{
		if (outer == null)
			throw new ArgumentNullException(nameof(outer));
		if (inner == null)
			throw new ArgumentNullException(nameof(inner));
		if (outerKeySelector == null)
			throw new ArgumentNullException(nameof(outerKeySelector));
		if (innerKeySelector == null)
			throw new ArgumentNullException(nameof(innerKeySelector));
		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));
		if (comparer == null)
			throw new ArgumentNullException(nameof(comparer));
		return MergeJoinIterator(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
	}
	private static IEnumerable<TResult> MergeJoinIterator<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IComparer<TKey> comparer)
	{
		IEnumerator<TOuter> outerEnumerator = outer.GetEnumerator();
		if (!outerEnumerator.MoveNext())
			yield break;
		IEnumerator<TInner> innerEnumerator = inner.GetEnumerator();
		if (!innerEnumerator.MoveNext())
			yield break;
		TOuter outerElement = outerEnumerator.Current;
		TKey outerKey = outerKeySelector(outerElement);
		TInner innerElement = innerEnumerator.Current;
		TKey innerKey = innerKeySelector(innerElement);
		int comp = comparer.Compare(innerKey, outerKey);
		while (true)
		{
			if (comp < 0)
			{
				if (!innerEnumerator.MoveNext())
					break;
				innerElement = innerEnumerator.Current;
				innerKey = innerKeySelector(innerElement);
				comp = comparer.Compare(innerKey, outerKey);
				continue;
			}
			if (comp > 0)
			{
				if (!outerEnumerator.MoveNext())
					break;
				outerElement = outerEnumerator.Current;
				outerKey = outerKeySelector(outerElement);
				comp = comparer.Compare(innerKey, outerKey);
				continue;
			}
			yield return resultSelector(outerElement, innerElement);
			if (!outerEnumerator.MoveNext())
			{
				while (true)
				{
					if (!innerEnumerator.MoveNext())
						break;
					innerElement = innerEnumerator.Current;
					innerKey = innerKeySelector(innerElement);
					comp = comparer.Compare(innerKey, outerKey);
					if (comp != 0)
						break;
					yield return resultSelector(outerElement, innerElement);
				}
				break;
			}
			if (!innerEnumerator.MoveNext())
			{
				while (true)
				{
					outerElement = outerEnumerator.Current;
					outerKey = outerKeySelector(outerElement);
					comp = comparer.Compare(innerKey, outerKey);
					if (comp != 0)
						break;
					yield return resultSelector(outerElement, innerElement);
					if (!outerEnumerator.MoveNext())
						break;
				}
				break;
			}
			TOuter outerElementNext = outerEnumerator.Current;
			TKey outerKeyNext = outerKeySelector(outerElementNext);
			TInner innerElementNext = innerEnumerator.Current;
			TKey innerKeyNext = innerKeySelector(innerElementNext);
			comp = comparer.Compare(outerKeyNext, outerKey);
			bool stop = false;
			if (comp != 0)
			{
				comp = comparer.Compare(innerKeyNext, innerKey);
				if (comp == 0)
				{
					yield return resultSelector(outerElement, innerElementNext);
					while (true)
					{
						if (!innerEnumerator.MoveNext())
						{
							stop = true;
							break;
						}
						innerElementNext = innerEnumerator.Current;
						innerKeyNext = innerKeySelector(innerElementNext);
						comp = comparer.Compare(innerKeyNext, outerKey);
						if (comp != 0)
							break;
						yield return resultSelector(outerElement, innerElementNext);
					}
					if (stop)
						break;
				}
				outerElement = outerElementNext;
				outerKey = outerKeyNext;
				innerElement = innerElementNext;
				innerKey = innerKeyNext;
				comp = comparer.Compare(innerKey, outerKey);
				continue;
			}
			comp = comparer.Compare(innerKeyNext, innerKey);
			if (comp != 0)
			{
				yield return resultSelector(outerElementNext, innerElement);
				while (true)
				{
					if (!outerEnumerator.MoveNext())
					{
						stop = true;
						break;
					}
					outerElementNext = outerEnumerator.Current;
					outerKeyNext = outerKeySelector(outerElementNext);
					comp = comparer.Compare(innerKey, outerKeyNext);
					if (comp != 0)
						break;
												
					yield return resultSelector(outerElementNext, innerElement);
				}
				if (stop)
					break;
				outerElement = outerElementNext;
				outerKey = outerKeyNext;
				innerElement = innerElementNext;
				innerKey = innerKeyNext;
				comp = comparer.Compare(innerKey, outerKey);
				continue;
			}
			yield return resultSelector(outerElement, innerElementNext);
			var innerRest = new List<TInner>();
			TInner innerElementFollowing = default(TInner);
			TKey innerKeyFollowing = default(TKey);
			while (true)
			{
				if (!innerEnumerator.MoveNext())
				{
					stop = true;
					break;
				}
				innerElementFollowing = innerEnumerator.Current;
				innerKeyFollowing = innerKeySelector(innerElementFollowing);
				comp = comparer.Compare(innerKeyFollowing, outerKey);
				if (comp != 0)
					break;
				yield return resultSelector(outerElement, innerElementFollowing);
				innerRest.Add(innerElementFollowing);
			}
			yield return resultSelector(outerElementNext, innerElement);
			yield return resultSelector(outerElementNext, innerElementNext);
			for (int i = 0; i < innerRest.Count; i++)
				yield return resultSelector(outerElementNext, innerRest[i]);
			while (true)
			{
				if (!outerEnumerator.MoveNext())
				{
					stop = true;
					break;
				}
				outerElementNext = outerEnumerator.Current;
				outerKeyNext = outerKeySelector(outerElementNext);
				comp = comparer.Compare(innerKey, outerKeyNext);
				if (comp != 0)
					break;
				yield return resultSelector(outerElementNext, innerElement);
				yield return resultSelector(outerElementNext, innerElementNext);
				for (int i = 0; i < innerRest.Count; i++)
					yield return resultSelector(outerElementNext, innerRest[i]);
			}
			if (stop)
				break;
			outerElement = outerElementNext;
			outerKey = outerKeyNext;
			innerElement = innerElementFollowing;
			innerKey = innerKeyFollowing;
			comp = comparer.Compare(innerKey, outerKey);
		}
	}
