	[DynamicData("TestMethodInput")]
	[DataTestMethod]
	public void TestMethod(string test)
	{
		Assert.AreEqual("test", test);
	}
	public static IEnumerable<object[]> TestMethodInput
	{
		get
		{
			return new[]
			{
				new object[] { stringproperty },
				new object[] { "test" }
			};
		}
	}
