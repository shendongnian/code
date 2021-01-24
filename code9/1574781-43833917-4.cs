	public interface IComparableReadOnlyDictionary<TKey, TValue>
		: IReadOnlyDictionary<TKey, TValue>
	{
		IEqualityComparer<TKey> Comparer { get; }
	}
