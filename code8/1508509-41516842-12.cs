	private static SortedList<double, Zip> FindClosest(Zip myZip)
	{
		var closestZips = new SortedList<double, Zip>();
		List<Zip> ZipCodes = new List<Zip>();
		foreach (var zip in ZipCodes.Where(x => x != myZip))
		{
			//Haversine magic returns distance (double) in km
			double dist = Haversine(myZip.Location, zip.Location);
			//If everything else is smaller, just skip it
			if (closestZips.Count < 5)
			{
				closestZips.Add(dist, zip);
			}
			else if (dist < closestZips.Keys[4])
			{
				closestZips.RemoveAt(4);
				closestZips.Add(dist, zip);
			}
		}
		return closestZips;
	}
