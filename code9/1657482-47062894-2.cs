	enum MyEnum
	{
		ValueA,
		ValueB,
		ValueC
	}
	static void MyFunction(Type type)
	{
		//...
	}
	static void CallMyFunction(MyEnum myEnum)
	{
        Type type;
		switch (myEnum)
		{
			case MyEnum.ValueA:
				type = typeof(A);
				break;
			case MyEnum.ValueB:
				type = typeof(B);
				break;
			case MyEnum.ValueC:
				type = typeof(C);
				break;                                                              
		}
		MyFunction(type);
	}
