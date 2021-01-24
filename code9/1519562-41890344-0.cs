    public List<SomeCls> GetResult(List<SomeCls> lstData)
    	{
    		List<SomeCls> lstResult;
    		
    		if(lstData.Any(x=>x.Status=="Finished"))
    		{
    		 	lstResult = lstData.Where(x=>x.Status=="Finished").ToList();
    		}
    		
    		else if(lstData.Any(x=>x.Status=="Closed"))
    		{
    			// Here assuming that there is only one Closed in whole list
    			int index = lstData.FindIndex(0,lstData.Count(),x=>x.Status=="Closed");
    		 	lstResult = lstData.GetRange(index,lstData.Count()-index);
    			
    			if(lstResult.Count()!=1) // check if it contains Open.
    			{
    				lstResult = lstResult.Where(x=>x.Status=="Open").ToList();
    			}
    		}
    		else // Only Open
    		{
    			lstResult = lstData;
    		}
    		return lstResult;
    	}
	
