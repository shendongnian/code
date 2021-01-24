    actionsLists.Add(new List<ActionSchedule> //or ActionScheduleCollection, or ActionScheduleGroup...
    {
        new ActionSchedule { Mode = TaskJob.Login, Start = new TimeSpan(9,0,0) },
        new ActionSchedule { Mode = TaskJob.Pause, Start = new TimeSpan(9,2,0) },
        new ActionSchedule { Mode = TaskJob.Resume, Start = new TimeSpan(10,0,0) },
        new ActionSchedule { Mode = TaskJob.Close, Start = new TimeSpan(15,0,0) }
    };
    actionsLists.Add(new List<ActionSchedule>
    {
        new ActionSchedule { Mode = TaskJob.Login, Start = new TimeSpan(17,0,0) },
        new ActionSchedule { Mode = TaskJob.Pause, Start = new TimeSpan(18,0,0) },
        new ActionSchedule { Mode = TaskJob.Resume, Start = new TimeSpan(18,30,0) },
        new ActionSchedule { Mode = TaskJob.Close, Start = new TimeSpan(21,0,0) }
    };
    actionsLists.Add(new List<ActionSchedule>
    {
        new ActionSchedule { Mode = TaskJob.Login, Start = new TimeSpan(22,0,0) },
        new ActionSchedule { Mode = TaskJob.Close, Start = new TimeSpan(6,0,0) }
    };
