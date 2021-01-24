    private static void getPaths(IList<string> allPaths, 
		                         string currentPath, 
		                         int height,
		                         int maxLength,
		                         int maxHeight)
	{
		if (currentPath.Length == maxLength)
		{
			if (height == 0)
			{
				allPaths.Add(currentPath);
			}
		}
		else
		{
			foreach (var d in GetAllPossibleDirectionsFrom(currentPath))
			{
				var newHeight = d == Up ? 
					height + 1 : 
					(d == Down ? height - 1 : height);
				if (newHeight < 0 /*illegal path*/ ||
				    newHeight > 
                        maxLength - (currentPath.Length + 1)) /*can not possibly
                                                                end with zero height*/
						continue;
					
				getPaths(allPaths, 
					     currentPath + d.ToString(), 
					     newHeight, 
					     maxLength, 
					     maxHeight);
			}
		}
	}
