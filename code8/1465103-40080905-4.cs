	var ob = Observable.Interval(TimeSpan.FromSeconds(1))
		.Publish(500);
	var connection = ob.Connect();
	//Note at this point `ob` has never been subscribed to, so the ReferenceCount is 0 i.e. has not be connected.
	var subscription = Observable.Timer(TimeSpan.FromSeconds(5)).Subscribe(x =>
	{
		// Try to get latest value from "ob" here.
		ob.First().Dump();
	});
	//Sometime later
	subscription.Dispose();
	connection.Dispose()
