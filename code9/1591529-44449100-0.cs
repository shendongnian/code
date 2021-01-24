	public static List<T> FindPath<T>(T origin, T target) where T : class, INode
	{
		var path = new List<T>();
		var cameFrom = new Dictionary<T, T>();
		var costToNode = new Dictionary<T, float>();
		var frontier = new PriorityQueue<T>();
		Dictionary<T, float> costSoFar = new Dictionary<T, float>();
		frontier.Enqueue(origin, 0);
		costSoFar[frontier[0].Element] = 0;
		while (frontier.Count > 0)
		{
			T current = frontier.Dequeue();
			foreach (var neighbour in current.GetNeighbours<T>())
			{
				float newCost = costSoFar[current] +
								current.GetMovementCost(neighbour);
				if (!costSoFar.ContainsKey(neighbour) || newCost < costSoFar[neighbour])
				{
					costSoFar[neighbour] = newCost;
					frontier.Enqueue(neighbour, newCost);
					cameFrom[neighbour] = current;
				}
			}
			if (current == target)
			{
				break;
			}
		}
		//build path
		T nn = target;
		while (nn != origin)
		{
			path.Add(nn);
			nn = cameFrom[nn];
		}
		path.Reverse();
		return path;
	}
