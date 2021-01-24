    void Test(bool f)
    {
  		if (f && instance is MyClass y)
		{
			var x = y;  //Error: Use of unassigned local variable
		}
    }
