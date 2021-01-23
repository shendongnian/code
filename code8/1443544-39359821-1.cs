	IObservable<GeoCoordinate> locationProvider = new GeoLocationProvider();
	
	locationProvider
		.Scan(Tuple.Create(GeoCoordinate.Zero,GeoCoordinate.Zero), (acc, cur)=>Tuple.Create(acc.Item2, cur))
		.Where(pair=>pair.Item1.DistanceTo(pair.Item2) > 10)
		.Select(pair=>pair.Item2)
		.Subscribe(
			pos => Console.WriteLine(pos),
			ex => { },
			() => {});
