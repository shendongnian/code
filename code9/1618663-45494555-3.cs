	// Can mix double with int :)
	var doubleAdd = Operations.Add(4.5, 3);
	
	// Can mix decimal with int :)
	var listAdd = Operations.AddAll(new[] {3, 6.7m, 0.3m});
	// Even empty enumerables
	var shortAdd = Operations.AddAll(Enumerable.Empty<short>());
	// This will not work for byte. System.Byte should be casted to System.Int32
	// Throws "InvalidOperationException: The binary operator Add is not defined for the types 'System.Byte' and 'System.Byte'."
    var byteAdd = Operations.AddAll(new byte[] {1, 2, 3});
