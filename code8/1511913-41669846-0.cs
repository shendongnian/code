	void Main()
	{
		Func<int> f = () => MyExecution(1, 2, 3, 4);
		
		//some time later
		int result = f();
	}
	
	public int MyExecution(int p1, int p2, int p3, int p4)
	{
		return p1 + p2 + p3 + p4;
	}
	
	
