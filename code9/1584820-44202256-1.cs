    private static string GetInvolvementLogging(ICollection<UserInvolvement> newInvolvement,
    			ICollection<UserInvolvement> oldInvolvement)
    {
    	var intersection = newInvolvement.Select(x => x.UserId).Intersect(oldInvolvement.Select(x => x.UserId));
    	var addedIds = newInvolvement.Select(x => x.UserId).Except(intersection);
    	var removedIds = oldInvolvement.Select(x => x.UserId).Except(intersection);
    
    	List<UserInvolvement> modifiedUI = new List<UserInvolvement>();
    
    	foreach (var i in intersection)
    	{
    		var ni = newInvolvement.First(a => a.UserId == i);
    		var oi = oldInvolvement.First(a => a.UserId == i);
    
    		if (!ni.Equals(oi))
    		{
    			modifiedUI.Add(ni);					
    		}
    	}
    
    	List<UserInvolvement> addedUI = newInvolvement.Where(x => addedIds.Contains(x.UserId)).Select(w => w).ToList();
    	List<UserInvolvement> removedUI = oldInvolvement.Where(x => removedIds.Contains(x.UserId)).Select(w => w).ToList();
    
    	StringBuilder sb = new StringBuilder();
    
    	sb.AppendLine("Added");
    	foreach (var added in addedUI)
    	{
    		sb.AppendLine(added.ToString());				
    	}
    	sb.AppendLine("Removed");
    	foreach (var removed in removedUI)
    	{
    		sb.AppendLine(removed.ToString());
    	}
    	sb.AppendLine("Modified");
    	foreach (var modified in modifiedUI)
    	{
    		sb.AppendLine(modified.ToString());
    	}
    
    	return sb.ToString();
    }
