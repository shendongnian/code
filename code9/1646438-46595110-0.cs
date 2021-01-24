	public static IEnumerable<IEnumerable<T>> GroupConnected<T>(this IEnumerable<T> list, Func<T,T,bool> connectionCondition)
	{
        if (list == null)
        {
            yield break;
        }
        using (var enumerator = list.GetEnumerator())
		{
            T prev = default(T);
            var temp = new List<T>();
            while (enumerator.MoveNext())
			{
    			T curr = enumerator.Current;
                {
                    if(!prev.Equals(default(T)) && !connectionCondition(prev, curr))
                    {
                        yield return temp;
                        temp = new List<T>();
                    }
                    temp.Add(curr);
                }
                prev = curr;
			}
            yield return temp;
		}
	}
