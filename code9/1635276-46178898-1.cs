    using DotSpatial.Projections;
    using DotSpatial.Topology;
    public static double CalculateArea(IEnumerable<double> latLonPoints)
    {
        // source projection is WGS1984
    	var projFrom = KnownCoordinateSystems.Geographic.World.WGS1984;
    	// most complicated problem - you have to find most suitable projection
    	var projTo = KnownCoordinateSystems.Projected.UtmWgs1984.WGS1984UTMZone37N;
        // prepare for ReprojectPoints (it's mutate array)
    	var z = new double[latLonPoints.Count() / 2];
    	var pointsArray = latLonPoints.ToArray();
    	Reproject.ReprojectPoints(pointsArray, z, projFrom, projTo, 0, pointsArray.Length / 2);
        // assemblying new points array to create polygon
    	var points = new List<Coordinate>(pointsArray.Length / 2);
    	for (int i = 0; i < pointsArray.Length / 2; i++)
    		points.Add(new Coordinate(pointsArray[i * 2], pointsArray[i * 2 + 1]));
    	var poly = new Polygon(points);
    	return poly.Area;
    }
