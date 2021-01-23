	dynamic a = 1;
	Console.WriteLine(a);
	// Dynamic now has a different type.
	a = new string[0];
	Console.WriteLine(a);
	// Assign to dynamic method result.
	a = Test();
	Console.WriteLine(a);
	// Use dynamic field.
	_y = "carrot";
	// You can call anything on a dynamic variable,
	// ... but it may result in a runtime error.
	Console.WriteLine(_y.Error);
