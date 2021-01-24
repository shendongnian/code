    void Test(bool f)
    {
  		if (f && instance is MyClass y)
		{
			var a = y;  //Error: Use of unassigned local variable
		}
    }
