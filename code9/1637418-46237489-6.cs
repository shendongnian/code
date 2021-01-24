	static void Main(string[] args)
	{
		var actions = new List<ActionSchedule>
		{
			new ActionSchedule { Mode = TaskJob.Login, Start = new TimeSpan(9,0,0) },
			new ActionSchedule { Mode = TaskJob.Pause, Start = new TimeSpan(9,2,0) },
			new ActionSchedule { Mode = TaskJob.Resume, Start = new TimeSpan(10,0,0) },
			new ActionSchedule { Mode = TaskJob.Close, Start = new TimeSpan(15,0,0) },
			new ActionSchedule { Mode = TaskJob.Login, Start = new TimeSpan(17,0,0) },
			new ActionSchedule { Mode = TaskJob.Pause, Start = new TimeSpan(18,0,0) },
			new ActionSchedule { Mode = TaskJob.Resume, Start = new TimeSpan(18,30,0) },
			new ActionSchedule { Mode = TaskJob.Close, Start = new TimeSpan(21,0,0) },
			new ActionSchedule { Mode = TaskJob.Login, Start = new TimeSpan(22,0,0) },
			new ActionSchedule { Mode = TaskJob.Close, Start = new TimeSpan(6,0,0) }
		};
		var actionLists = new List<List<ActionSchedule>>();
		List<ActionSchedule> actionList = null;
		foreach (var action in actions)
		{
			if (action.Mode == TaskJob.Login)
			{
				actionList = new List<ActionSchedule>();
				actionLists.Add(actionList);
			}
			actionList.Add(action);
		}
		Console.WriteLine("Time is 10:00:00");
		PrintGroup(GetCurrentGroup(actionLists, new TimeSpan(10, 0, 0)));
		Console.WriteLine("Time is 14:00:00");
		PrintGroup(GetCurrentGroup(actionLists, new TimeSpan(14, 0, 0)));
		Console.WriteLine("Time is 16:00:00");
		PrintGroup(GetCurrentGroup(actionLists, new TimeSpan(16, 0, 0)));
		Console.WriteLine("Time is 20:00:00");
		PrintGroup(GetCurrentGroup(actionLists, new TimeSpan(20, 0, 0)));
		Console.WriteLine("Time is 23:00:00");
		PrintGroup(GetCurrentGroup(actionLists, new TimeSpan(23, 0, 0)));
		Console.WriteLine("Time is 05:00:00");
		PrintGroup(GetCurrentGroup(actionLists, new TimeSpan(5, 0, 0)));
		Console.WriteLine("Time is 07:00:00");
		PrintGroup(GetCurrentGroup(actionLists, new TimeSpan(7, 0, 0)));
		Console.ReadLine();
	}
	private static void PrintGroup(List<ActionSchedule> group)
	{
		Console.WriteLine($"Login: {group.Single(a => a.Mode == TaskJob.Login).Start}, Closing: {group.Single(a => a.Mode == TaskJob.Close).Start}");
	}
