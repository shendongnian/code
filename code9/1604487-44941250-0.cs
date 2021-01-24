    List<DailyRoutine> d = new List<DailyRoutine>()
    {
    	new DailyRoutine() { Date = new DateTime(2017, 7, 1)},
    	new DailyRoutine() { Date = new DateTime(2017, 7, 2)},
    	new DailyRoutine() { Date = new DateTime(2017, 7, 3)},
    	new DailyRoutine() { Date = new DateTime(2017, 7, 4)},
    	new DailyRoutine() { Date = new DateTime(2017, 7, 5)}
    };
    
    DailyRoutine newDr = new DailyRoutine() { Date = new DateTime(2017, 7, 2) };
    DailyRoutine oldDr = d.Where(dr => dr.Date == newDr.Date).FirstOrDefault();
    
    if (oldDr != null)
    {
    	int idx = d.IndexOf(oldDr);
    	List<DailyRoutine> changeList = d.Where((dr, i) => i >= idx).ToList();
    
    	foreach (DailyRoutine i in changeList)
    	{
    		i.Date = i.Date.AddDays(1);
    	}
    
    	d.Insert((int)idx, newDr);
    }
    else
    {
    	d.Add(newDr);
    }
