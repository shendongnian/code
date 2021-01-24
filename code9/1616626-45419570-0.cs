    public long LogError(ApplicationErrorLog error)
    {
    	try
    	{
    		return InsertErrorLog(error);
    	}
    	catch(Exception ex)
    	{
    		//Do some stuff here to send your email
    		return 0;
    	}
    }
    
    private long InsertErrorLog(ApplicationErrorLog error)
    {
    	var application = new SqlParameter("@Application", error.Application);
    	var objectId = new SqlParameter("@ObjectId", error.ObjectId);
    	var exceptionMessage = new SqlParameter("@ExceptionMessage", error.ExceptionMessage);
    	var stackTrace = new SqlParameter("@StackTrace", error.StackTrace);
    	var innerExceptions = (error.InnerException != null)
    		? GetInnerExceptions(error.InnerException)
    		: string.Empty;
    	var innerException = new SqlParameter("@InnerException", innerExceptions);
    	var createdBy = new SqlParameter("@CreatedBy", error.CreatedBy);
    	var date = new SqlParameter("@CreatedDatetime", error.CreatedDateTime);
    	var returnCode = new SqlParameter("@ReturnVal", SqlDbType.BigInt)
    	{
    		Direction = ParameterDirection.Output
    	};
    	var parameters = new List<SqlParameter>()
    		{
    			application,
    			objectId,
    			exceptionMessage,
    			stackTrace,
    			innerException,
    			createdBy,
    			date,
    			returnCode
    		};
    	Database.SqlQuery<object>("exec @ReturnVal = sp_Insert_ErrorLog @Application, @ObjectId, @ExceptionMessage, @StackTrace, @InnerException, @CreatedBy, @CreatedDatetime", parameters.ToArray()).FirstOrDefault();
    	returnCode.ToString();
    	return (int)returnCode.Value;
    }
