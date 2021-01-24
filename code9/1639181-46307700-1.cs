	public void AddADomesticTestClass<T>() where T: DomesticTestClass, new()
	{
		SupportedTests.Add(new T());
	}
	
	public void AddAnInternationalTestClass<T>() where T: InternationalTestClass, new()
	{
		SupportedTests.Add(new T());
	}
