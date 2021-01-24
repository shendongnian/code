	[DynamicData("TestMethodInput")]
	[DataTestMethod]
	public void TestMethod(List<string> list)
	{
		Assert.AreEqual(2, list.Count);
	}
	public static IEnumerable<object[]> TestMethodInput
	{
		get
		{
			return new[]
			{
				new object[] { new List<string> { "one" } },
				new object[] { new List<string> { "one", "two" } },
				new object[] { new List<string> { "one", "two", "three" } }
			};
		}
	}
