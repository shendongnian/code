    public ActionResult Index()
    { 
		var events = this.db.Events
						 .OrderBy(e => e.StartDateTime)
						 .Where(e => e.IsPublic);
		
		var upcomingEvents = events.Where(e => e.StartDateTime > DateTime.Now);
		var passedEvents = events.Where(e => e.StartDateTime <= DateTime.Now);
		
		return View(new UpcomingPassedEventsViewModel()
		{
			UpcomingEvents = upcomingEvents.Select(Map).ToList(),
			PassedEvents = passedEvents.Select(Map).ToList()
		});
    }
	private EventViewModel Map(EventDataModel e)
	{
		return new EventViewModel()
		{
			Id = e.Id,
			Title = e.Title,
			Duration = e.Duration,
			Author= e.Author.FullName,
			Location = e.Location
		};
	}
