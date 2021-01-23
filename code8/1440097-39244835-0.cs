	var interfaceMethods = typeof(PurchaseOrder)
		.GetInterfaces()
		.Select(x => typeof(PurchaseOrder).GetInterfaceMap(x))
		.SelectMany(x => x.TargetMethods);
	
	var propsNotFromInterface= typeof(PurchaseOrder)
		.GetProperties((BindingFlags)62)
		.Where(x => !x.GetAccessors(true).Any(y => interfaceMethods.Contains(y)));
	
	Console.WriteLine(propsNotFromInterface.ToArray().Length);
