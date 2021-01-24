	var operations = new Operation[]
	{
		new BugOperation() { TaskType = "BUGS", PropertyName = "SpentTimeHours", Source = GraphTable._Bugs, Select = x => x.SpentTimeHours, Incremement = v => TotalBugs += v },
		new BugOperation() { TaskType = "BUGS", PropertyName = "RemainingTimeHours", Source = GraphTable._Bugs, Select = x => x.RemainingTimeHours, Incremement = v => TotalBugs += v  },
		new BugTaskOperation() { TaskType = "TASKS_BUGS", PropertyName = "SpentTimeHours", Source = GraphTable._BugTask, Select = x => x.SpentTimeHours, Incremement = v => TotalTaskBugs += v  },
		new BugTaskOperation() { TaskType = "TASKS_BUGS", PropertyName = "RemainingTimeHours", Source = GraphTable._BugTask, Select = x => x.RemainingTimeHours, Incremement = v => TotalTaskBugs += v  },
	};
	var query =
		from ids in result
		from operation in
			operations
				.Where(x => x.TaskType == ids.TaskType.ToUpper())
				.Where(x => propertyName == x.PropertyName)
				.Take(1)
		where operation != null
		select new { ids, operation }
	
	foreach (var x in query)
	{
		x.operation.Update(x.ids.Aid);
	}
