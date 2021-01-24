    public static class EnumerableExtensions
    {
    	public static IEnumerable<AvailabilityDto> FindAvailabilityGaps(this IEnumerable<AvailabilityDto> source)
    	{
    		if (source == null)
    		{
    			yield break;
    		}
    		
    		var sorted = source.OrderBy(x => x.StartDateTime).ThenBy(x => x.EndDateTime);
    		
    		using (var e = sorted.GetEnumerator())
    		{
    			if (!e.MoveNext())
    			{
    				yield break;
    			}
    			
    			var latestEndTime = e.Current.EndDateTime;
    			
    			while (e.MoveNext())
    			{
    				if (e.Current.StartDateTime > latestEndTime)
    				{
    					yield return new AvailabilityDto
    					{
    						StartDateTime = latestEndTime,
    						EndDateTime = e.Current.StartDateTime
    					};
    				}
    				
    				if (e.Current.EndDateTime > latestEndTime)
    				{
    					latestEndTime = e.Current.EndDateTime;
    				}
    			}
    		}
    	}
    }
