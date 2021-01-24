	public interface IComparableReadOnlyDictionary<TKey, TValue>
		: IReadOnlyDictionary<TKey, TValue>
	{
		IComparer<TKey> Comparer { get; }
	}
