	public void TestMethod<TKey, TValue>(Dictionary<TKey, TValue> dict, Func<TKey, TValue> func)
	{
		foreach (var test in dict)
		{
			 if (test.Value is ICollection)
			 {
				  CollectionAssert.AreEqual((ICollection)test.Value, (ICollection)func(test.Key));
			 }
			 else
			 {
				  Assert.AreEqual(test.Value, func(test.Key));
			 }
		}
	}
