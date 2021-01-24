    var emptyResults = new List<object>();
    			var days = Enumerable.Range(1, DateTime.DaysInMonth(firstDay.Year, firstDay.Month))
    				.Select(day => new DateTime(firstDay.Year, firstDay.Month, day))
    				.ToList();
    
    			foreach (var date in days)
    			{
    				var exists = results.Any(x => x.Date == date);
    				if (!exists)
    				{
    					emptyResults.Add(new
    					{
    						Date = date,
    						PID = "",
    						SPID = "",
    						ProcessName = "",
    						SubProcessName = "",
    						Task = "",
    						SubTask = "",
    						Hours = 0
    					});
    				}
    			}
    
    			var filledResults = results.Concat(emptyResults).ToList();
