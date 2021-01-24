    public class Logger : IActivityLogger
    {
    	public static ConcurrentDictionary<string, List<IActivity>> Messages = new ConcurrentDictionary<string, List<IActivity>>();
    
    	public Task LogAsync(IActivity activity)
    	{
    		var list = new List<IActivity>() { activity };            
    		Messages.AddOrUpdate(activity.Conversation.Id, list, (k, v) => { v.Add(activity); return v; });
    		return Task.FromResult(false);
    	}
    }
