	private static SortedList<Zip, double> FindClosest(Zip myZip)
	{
		var closestZips = new SortedList<Zip, double>();
		foreach (var zip in ZipCodes.Where(x => x != myZip))
		{
			//Haversine magic returns distance (double) in km
			double dist = Haversine(myZip.Location, zip.Location);
			if(closestZips.Count < 5)
			{
				closestZips.Add(zip, dist);
			}
			else if(dist < closestZips[closestZips.Keys[4]])
			{
				closestZips.RemoveAt(4);
				closestZips.Add(zip, dist);
			}
		}
		return closestZips;
	}
