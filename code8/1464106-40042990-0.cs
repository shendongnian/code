	public static IEnumerable<T> Omit<T>(this IEnumerable<T> sequence, 
        params Action<T>[] omissions)
	{
		foreach (var element in sequence)
		{
			foreach (var omission in omissions)
			{
				omission(element);
			}
			yield return element;
		}
	}
