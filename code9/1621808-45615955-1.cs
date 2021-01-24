    protected class BranchData
    {
    	public string Name { get; set; }
    	public string Merged { get; set; }
    	public string Protected { get; set; }
    	public CommitData Commit { get; set; }
    }
    
    protected class CommitData
    { 
        [JsonProperty(PropertyName = "authored_date")]
    	public string AuthoredDate { get; set; }
    	//...other Commit object properties
    }
