    public void AddATestClass<T>() where T: TestClass, new()
    {
    	if (typeof(T).IsAssignableFrom(typeof(DomesticTestClass))
    		|| typeof(T).IsAssignableFrom(typeof(InternationalTestClass)))
    	{
    		SupportedTests.Add(new T());
    	}
    }
