	//Change to 'Assembly.Load' so the last line will not throw.
	Assembly assembly = Assembly.ReflectionOnlyLoad("DllOfB");
	Type runtimeType = Type.GetType("System.RuntimeType");
	MethodInfo createEnum = runtimeType.GetMethod("CreateEnum", /*BindingFlags*/);
	MethodInfo getRuntimeType = typeof(RuntimeTypeHandle).GetMethod("GetRuntimeType", /*BindingFlags*/);
	Type bType = assembly.GetType("DllOfB.B");
	//Throws 'InvalidOperationException':
	object res = createEnum.Invoke(null, new [] { getRuntimeType.Invoke(bType.TypeHandle, new object[]{}), 1 });
