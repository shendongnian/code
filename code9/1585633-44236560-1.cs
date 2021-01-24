	int num = 5;
	Delegate del = CreateLambda(num);
	
	// Note that we have to convert to object the various parameters,
	// because DynamicInvoke uses a object[]
	object[] values = Enumerable.Range(1, num).Select(x => (object)x).ToArray();
	int result = (int)del.DynamicInvoke(values);
	
	Console.WriteLine("{0}={1}", string.Join("+", values), result);
