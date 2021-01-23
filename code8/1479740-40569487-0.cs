	var availableExtensionMethods = assemblies
		// First get all the types
		.SelectMany(asse => asse.GetExportedTypes())
		// Cut out some which cannot be static classes first
		.Where(t => t.IsAbstract && t.IsSealed && t.GetConstructors().Length == 0)
		// Get all their methods.
		.SelectMany(t => t.GetMethods())
		// Restrict to just the extension methods
		.Where(m => m.GetCustomAttributes().Any(ca => ca is System.Runtime.CompilerServices.ExtensionAttribute)
		// An extension method must have at least one parameter, but we'll rule out being
		// messed up by some strangely defined method through weird direct use of
		// the ExtensionAttribute attribute
		&& m.GetParameters().Length != 0)
		// Get an object with the method and the first parameter we'll use below.
		.Select(m => new {Method = m, FirstParam = m.GetParameters()[0]});
