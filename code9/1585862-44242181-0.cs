	[TestMethod]
	public void TestMethod1()
	{
		var type = Assembly.GetExecutingAssembly().GetType("ClassLibrary2.SomeClass");
		var nestedType = type.GetNestedType("SomePrivateClass", BindingFlags.NonPublic);
		var method = nestedType.GetMethod("AddtwoNum", BindingFlags.Static | BindingFlags.NonPublic);
		method.Invoke(null, new object[] { default(int), default(int) });
	}
