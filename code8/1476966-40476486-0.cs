	var assemblyName = new AssemblyName { Name = "asd" };
	var moduleBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run).DefineDynamicModule(assemblyName.Name);
	var tb = moduleBuilder.DefineType("Foo");
	var genParams = tb.DefineGenericParameters("U");
	var miEqualsT = typeof(IEquatable<>).GetMethod("Equals", typeof(IEquatable<>).GetGenericArguments());
	var myMethod = tb.DefineMethod("Equals", MethodAttributes.Public | MethodAttributes.Virtual, typeof(bool), genParams);
	
	var il = myMethod.GetILGenerator();
	il.Emit(OpCodes.Ldstr, "I was invoked!");
	il.Emit(OpCodes.Call, GetMethod<string>(a => Console.WriteLine(a)));
	il.Emit(OpCodes.Ldc_I4_1);
	il.Emit(OpCodes.Ret);
	
	tb.AddInterfaceImplementation(typeof(IEquatable<>));
	tb.DefineMethodOverride(myMethod, miEqualsT);
		
	var t = tb.CreateType();
