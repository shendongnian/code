    void Test(bool f)
    {
        object neverAssigned;
        if (false && f)
		{
    		var x = neverAssigned;  //OK (never executes)
		}
    }
