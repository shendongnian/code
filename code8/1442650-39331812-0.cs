	public void TestTemplate(Action<object> action,Type t)
	{
		// pseudocode
		m_funcDict[t.GetHashCode()] += action;
	}
	public void TestUsage(object arg)
	{
		Type t = arg.GetType();
		TestTemplate(TestUsage,t);
	}
