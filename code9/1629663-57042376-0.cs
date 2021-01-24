    [Theory]
    [InlineData(2, 3,
    	new[] { "val1", "val2", "val3" },
    	new[] { "val4", "val5", "val6" }
    )]
    [InlineData(3, 2,
    	new[] { "val1", "val2" },
    	new[] { "val3", "val4" },
    	new[] { "val4", "val5" }
    )]
    public void MyTestMethod(int exptectedOuterCount, int expectedInnerCount, params string[][] myArray)
    {
    	Assert.Equal(exptectedOuterCount, myArray.Length);
    
    	foreach (var innerArray in myArray)
    	{
    		Assert.Equal(expectedInnerCount, innerArray.Length);
    	}
    }
