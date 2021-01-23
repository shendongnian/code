    Type[] types = new Type[]
	{
		leftType, // DateTime in your case
		rightType // DateTime in your case
	};
	BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
    // Method name is "op_Subtraction" in your case
	MethodInfo methodInfo = nonNullableType.GetMethodValidated(name, bindingAttr, null, types, null);
