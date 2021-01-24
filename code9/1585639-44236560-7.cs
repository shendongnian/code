	int num = 5;
	Delegate del = CreateLambda<double>(num);
	
	// Note that we have to convert to object the various parameters,
	// because DynamicInvoke uses a object[]
	object[] values = Enumerable.Range(1, num).Select(x => (object)(double)x).ToArray();
	double result = (double)del.DynamicInvoke(values);
	
	Console.WriteLine("{0}={1}", string.Join("+", values), result);
