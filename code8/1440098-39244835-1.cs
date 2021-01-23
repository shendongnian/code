	var interfaceMethods = typeof(PurchaseOrder)
		.GetInterfaces()
		.Select(x => typeof(PurchaseOrder).GetInterfaceMap(x))
		.SelectMany(x => x.TargetMethods).ToArray();
	
	var propsNotFromInterface= typeof(PurchaseOrder)
		.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.FlattenHierarchy)
		.Where(x => !x.GetAccessors(true).Any(y => interfaceMethods.Contains(y))).ToArray();
	
	Console.WriteLine(propsNotFromInterface.Length);
