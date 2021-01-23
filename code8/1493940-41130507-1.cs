    public enum EventType
    {
		AvailableBegin,
		AvailableEnd,
		UnavailableBegin,
		UnavailableEnd
	}
	public class Event
	{
		public DateTime Date;
		public EventType Type;
	}
	public class TimeRange
	{
		public DateTime Start;
		public DateTime End;
	}
	[TestMethod]
	public void q41029109single()
	{
		var availabilties = new List<TimeRange> {
			new TimeRange { Start = new DateTime(2016, 1, 1), End = new DateTime(2016, 2, 15) },
			new TimeRange { Start = new DateTime(2016, 2, 20), End = new DateTime(2016, 12, 15) }
		};
		var unavailabilities = new List<TimeRange> {
			new TimeRange { Start = new DateTime(2016, 2, 16), End = new DateTime(2016, 2, 25) }
		};
		var timeline = new List<Event>();
		foreach (var availability in availabilties)
		{
			timeline.Add(new Event { Date = availability.Start, Type = EventType.AvailableBegin });
			timeline.Add(new Event { Date = availability.End, Type = EventType.AvailableEnd });
		}
		foreach (var unavailability in unavailabilities)
		{
			timeline.Add(new Event { Date = unavailability.Start, Type = EventType.UnavailableBegin });
			timeline.Add(new Event { Date = unavailability.End, Type = EventType.UnavailableEnd });
		}
		
		var result = new List<TimeRange>();
		TimeRange currentAvailability = null;
		var insideUnavailable = false;
		var insideAvailable = false;
		foreach (var oneEvent in timeline.OrderBy(x => x.Date))
		{
			switch (oneEvent.Type)
			{
				case EventType.AvailableBegin:
					insideAvailable = true;
					if (insideUnavailable == false)
					{
						currentAvailability = new TimeRange { Start = oneEvent.Date };
					}
					break;
				case EventType.AvailableEnd:
					insideAvailable = false;
					if (insideUnavailable == false && currentAvailability != null)
					{
						currentAvailability.End = oneEvent.Date;
						result.Add(currentAvailability);
					}
					break;
				case EventType.UnavailableBegin:
					insideUnavailable = true;
					if (insideAvailable && currentAvailability != null)
					{
						currentAvailability.End = oneEvent.Date;
						result.Add(currentAvailability);
					}
					break;
				case EventType.UnavailableEnd:
					insideUnavailable = false;
					if (insideAvailable)
					{
						currentAvailability = new TimeRange { Start = oneEvent.Date.AddDays(1) };
					}
					break;
				default:
					break;
			}
		}
		//result should be good here.
	}
