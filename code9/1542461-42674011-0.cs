    public class Sqljob : IJob
    {
	    #region Constructors
	    public Sqljob()
	    {		
	    }
	    #endregion
	    #region IJob members
	    public void Execute(IJobExecutionContext context)
	    {
		    // Perform your SQl work here
	    }
	    #endregion
    }
