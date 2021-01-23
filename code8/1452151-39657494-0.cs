    public void CreateEvent(Event newEvent)
    {
    	var flags = "1,2,3";
    	string[] idArr = flags.Split(',');
    	using (var ctx = new Context())
    	{
    		foreach (string idString in idArr)
			    newEvent.Flags.Add(ctx.GetFlagByID(Convert.ToInt32(idString)));
    		ctx.Events.AddOrUpdate(newEvent);
    		ctx.SaveChanges();
    	}
    }
