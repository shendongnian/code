	private static SortedList<double, Zip> FindClosest(Zip myZip)
	{
		var closestZips = new SortedList<double, Zip>();
		foreach (var zip in ZipCodes)
		{
			if(zip != myZip)
			{
				//Haversine magic returns distance (double) in km
				double dist = Haversine(myZip.Location, zip.Location);
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
		}
		return closestZips;
	}
