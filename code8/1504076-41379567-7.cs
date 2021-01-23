	public static IEnumerable<string> GetWords(char[,] 
		                                       matrix,
		                                       Coordinates startingPoint,
		                                       int minimumLength,
		                                       int maximumLength)
	{
		var visited = ImmutableStack<Coordinates>.Empty;
		var path = ImmutableStack<char>.Empty;
		return getWords(matrix,
						path,
						visited,
						startingPoint,
						minimumLength,
						maximumLength).Select(chars => new string(chars.ToArray()));
	}
	static IEnumerable<string> getWords(char[,] matrix,
										ImmutableStack<char> path,
										ImmutableStack<Coordinates> visited,
										Coordinates coordinates,
										int minimumLength,
										int maximumLength)
	{
		var newPath = path.Push(matrix[coordinates.Row, coordinates.Column]);
		var newVisited = visited.Push(coordinates);
		if (newPath.Count > maximumLength)
		{
		    yield break;
		}
		else if (newPath.Count >= minimumLength)
		{
			yield return new string(newPath.Reverse().ToArray());
		}
		foreach (Coordinates neighbor in coordinates.GetNeighbors(matrix.GetLength(0),                                                                           matrix.GetLength(1)))
		{
			if (!visited.Contains(neighbor))
			{
				foreach (var word in getWords(matrix,
											  newPath,
											  newVisited,
											  neighbor,
											  minimumLength,
											  maximumLength))
				{
				    yield return word;
				}
			}
		}
	}
