    class Job : IComparable<Job>
    {
    	public string Description { get; set;}
    	
    	public int HoursToComplete { get; set;}
    	
    	public double HourlyRate { get; set;}
    	
    	public double TotalFee { get; set;}
    
    	public Job(string description, 
    	           int hoursToComplete, 
    			   double hourlyRate, 
    			   double totalFee)
    	{
    		Description = description;
    		HoursToComplete = hoursToComplete;
    		HourlyRate = hourlyRate;
    		TotalFee = totalFee;
    	}
    
    	public int CompareTo(Job otherJob)
    	{
    		int returnVal;
    		
    		if (this.TotalFee > otherJob.TotalFee)
    			returnVal = 1;
    		else
    			if (this.TotalFee < otherJob.TotalFee)
    			returnVal = -1;
    		else
    			returnVal = 0;
    			
    		return returnVal;
    	}
    }
