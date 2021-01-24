    protected class BranchData
    {
    	public string Name { get; set; }
    	public string Merged { get; set; }
    	public string Protected { get; set; }
    	public CommitData Commit { get; set; }
    }
    
    protected class CommitData
    { 
    	public string Authored_Date { get; set; }
    	//...other Commit object properties
    }
