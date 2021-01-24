	private static bool IsStrictlyIncreasing<T>(this IEnumerable<T> sequence)
		where T : IComparable<T>
	{
		using (var e = sequence.GetEnumerator())
		{
			if (!e.MoveNext())
				return true;
			var previous = e.Current;
			while (e.MoveNext())
			{
				if (e.Current.CompareTo(previous) <= 0)
					return false;
				previous = e.Current;
			}
			return true;
		}
	}
