		var filter = new[] {2, 3};
		
		var filteredResult = schedules
			.Join(dates, s => s.DateId, d => d.DateId, (s, d) => new{ s, d})
			.Join(tasks, s => s.s.TaskId, t => t.TaskId, (sd, t) => new	{ Person = sd.s, Date = sd.d, Task = t })
			.Where(x => filter.Contains(x.Date.DateId))
			.GroupBy(x => x.Person.Name)
			.Select(group => new 
					{
						Person = group.Key, 
						TasksByDay = group.ToDictionary(o => o.Date.Desc, o => o.Task.Desc)
					})
			.ToList();
		
		
		foreach (var item in filteredResult)
		{
			System.Console.WriteLine(item.Person);
			foreach (var keyvaluepair in item.TasksByDay)
			{
				System.Console.WriteLine(keyvaluepair.Key + " - " + keyvaluepair.Value);
			}
			System.Console.WriteLine("---");
		}
