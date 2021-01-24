	public static bool checkForEmployeeCode(string SSN)
	{
	    MyEntities ETC = new MyEntities();
	    var checkSsn = ETC.Applicants1
	    	.WithSSN(ssn)
	    	.FirstOrDefault();
	    if (checkSsn != null)
	    {....
    }
