    using System.Threading;
    using System.Threading.Tasks;
	private static Object thisLock = new Object();
	private static SortedList<double, Zip> FindClosest2(Zip myZip)
	{
		var closestZips = new SortedList<double, Zip>();
		Parallel.ForEach(ZipCodes, (zip) =>
		 {
			 //Haversine magic returns distance (double) in km
			 double dist = Haversine.calculate(myZip.Location, zip.Location);
			 if (closestZips.Count() < 6)
			 {
				 lock(thisLock)
				 {
					 closestZips.Add(dist, zip);
				 }
			 }
			 else if (dist < closestZips.Keys[4])
			 {
				 lock(thisLock)
				 {
					 closestZips.RemoveAt(4);
					 closestZips.Add(dist, zip);
				 }
			 }
		 });
		return closestZips;
	}
