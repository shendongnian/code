    static IEnumerable<Edge<T>> Order<T>(this IEnumerable<Edge<T>> edges)
		where T:IEquatable<T>
	{
		Debug.Assert(edges.Any());
		var map = new Dictionary<T, Edge<T>>();
		foreach (var e in edges)
		{
			if (map.ContainsKey(e.Node1))
			{
				Debug.Assert(!map.ContainsKey(e.Node2));
				map.Add(e.Node2, e);
			}
			else
			{
				map.Add(e.Node1, e);
			}
		}
		var current = edges.First();
		var orderedEdges = new HashSet<Edge<T>>();
		do
		{
			orderedEdges(current);
			yield return current;
			if (orderedEdges.Count == map.Count)
				break;
			var next = map[current.Node2];
			current = orderedEdges.Contains(next) ? map[current.Node1] : next;
		}
		while (true);
	}
