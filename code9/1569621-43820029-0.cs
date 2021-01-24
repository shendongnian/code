	public static unsafe void SetValue<T>(object inst, FieldInfo fi, T val)
	{
		var mi = typeof(TypedReference).GetMethod("InternalMakeTypedReference", BindingFlags.NonPublic | BindingFlags.Static);
		var sig = MethodSignature.FromMethodInfo(mi);
		var del = ReflectionTools.NewCustomDelegateType(sig.ReturnType, sig.ParameterTypes);
		var inv = mi.CreateDelegate(del);
		TypedReference tr;
		var ptr = Pointer.Box(&tr, typeof(void*));
		inv.DynamicInvoke(ptr, inst, new[]{fi.FieldHandle.Value}, fi.FieldType);
		__refvalue(tr, T) = val;
	}
