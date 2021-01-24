    public static IList<string> GetAllShroderPaths(int n)
	{
		var allPaths = new List<string>();
		getPaths(allPaths, "", 0, 2 * n, n);
		return allPaths;
	}
	private static void getPaths(IList<string> allPaths, 
		                         string currentPath, 
		                         int height,
		                         int maxLength,
		                         int maxHeight)
	{
		if (height < 0 || //illegal path
			height > maxLength - currentPath.Length) //can not possibly end with zero height
		    return;
			
		if (currentPath.Length == maxLength)
		{
			if (height == 0)
			{
				allPaths.Add(currentPath);
			}
		}
		else
		{
			var possibleDirections = currentPath.Length == 0 ? 
				all : PossibleDirectionsFrom(currentPath[currentPath.Length - 1]);
			foreach (var d in possibleDirections)
			{
				var newHeight = d == Up ? 
					height + 1 : 
					(d == Down ? height - 1 : height);
					
				getPaths(allPaths, 
					     currentPath + d.ToString(), 
					     newHeight, 
					     maxLength, 
					     maxHeight);
			}
		}
	}
