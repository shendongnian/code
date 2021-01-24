    void Test(bool f)
    {
        object neverAssigned;
		if (false & f)
		{
			var x = neverAssigned;  //Error: Use of unassigned local variable
		}
    }
