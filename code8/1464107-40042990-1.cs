	public static IEnumerable<T> ApplyToAll<T>(this IEnumerable<T> sequence, 
        params Action<T>[] action)
	{
		foreach (var element in sequence)
		{
			foreach (var action in actions)
			{
				omission(action);
			}
			yield return element;
		}
	}
