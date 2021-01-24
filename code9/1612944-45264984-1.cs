	var xs = new[] { 1, 2, 3 };
	var ie = ImmutableEnumerator<int>.Create(xs);
	if (ie.Succesful)
	{
		Console.WriteLine(ie.NewEnumerator.Current);
		var ie1 = ie.NewEnumerator.MoveNext();
		if (ie1.Succesful)
		{
			Console.WriteLine(ie1.NewEnumerator.Current);
			var ie2 = ie1.NewEnumerator.MoveNext();
			if (ie2.Succesful)
			{
				Console.WriteLine(ie2.NewEnumerator.Current);
				var ie3 = ie2.NewEnumerator.MoveNext();
			}
		}
	}
