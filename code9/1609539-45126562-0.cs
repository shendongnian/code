    public void AssertException<T>(Action act) where T : Exception
	{
		try
		{
			act();
		}
		catch (T e)
		{
			Assert.Fail();
		}
		catch (Exception e)
		{
			Assert.Pass();
		}
	}
