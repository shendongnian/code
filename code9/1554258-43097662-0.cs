    public class PagedResults<T>
    {
    	public PagedResults()
    	{
		    Results = new List<T>();
	    }
	    /// <summary>
	    /// Continuation Token for DocumentDB
	    /// </summary>
	    public string ContinuationToken { get; set; }
    	/// <summary>
    	/// Results
    	/// </summary>
    	public List<T> Results { get; set; }
    }
