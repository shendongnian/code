	public static IList<string> GetAllShroderPaths(int n)
	{
		var allPaths = new List<string>();
		getPaths(allPaths, "", 0, 2 * n, n);
		return allPaths;
	}
