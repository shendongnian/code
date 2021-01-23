    static IEnumerable<string> getWords(char[,] matrix,
								        ImmutableStack<char> path,
										ImmutableStack<Coordinates> visited,
									    Coordinates coordinates,
										int minimumLength,
										int maximumLength)
