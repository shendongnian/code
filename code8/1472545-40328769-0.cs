    public class Project
    {
    	// ...
    	public static Expression<Func<Project, bool>> IsVisibleForResearcher(string userId)
    	{
    		return p => p.Type == Enums.ProjectType.Open ||
    					p.Invites.Any(i => i.InviteeId == userId);
    	}
    }
