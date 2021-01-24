	[Fact]
	public void Exception()
	{
		Action testCode = () => { throw new InvalidOperationException(); };
		var ex = Record.Exception(testCode);
		Assert.NotNull(ex);
		Assert.IsType<InvalidOperationException>(ex);
	}
