	public static IEnumerable<string> GetWords(char[,] 
		                                       matrix,
		                                       Coordinates startingPoint,
		                                       int minimumLength,
		                                       int maximumLength)
		=> getWords(matrix,
				    ImmutableStack<char>.Empty,
					ImmutableStack<Coordinates>.Empty,
					startingPoint,
					minimumLength,
					maximumLength);
	
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
		foreach (Coordinates neighbor in coordinates.GetNeighbors(matrix.GetLength(0), matrix.GetLength(1)))
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
