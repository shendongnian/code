	var conn = Observable.Create<int>(o =>
		{
			Debug.WriteLine("Opening");
			o.OnNext(1);
			o.OnCompleted(); //This forces closing code to be called. Comment me out.
			return Disposable.Create(() =>
			{
				Debug.WriteLine("Closing");
			});
		})
		//.Replay(1)
		//.RefCount() //.Replay(1).RefCount is necessary if you want to cache the result
		;
	var sub1 = conn.SelectMany(i => Observable.Return(i)).Subscribe(i => Debug.WriteLine($"1: {i}"));
	var sub2 = conn.SelectMany(i => Observable.Return(i)).Subscribe(i => Debug.WriteLine($"2: {i}"));
	sub1.Dispose();
	sub2.Dispose();
	var sub3 = conn.SelectMany(i => Observable.Return(i)).Subscribe(i => Debug.WriteLine($"3: {i}"));
	sub3.Dispose();
