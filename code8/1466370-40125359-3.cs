	var teachersById = data
		.GroupBy(x => x.TeacherId)
		.Select(group => new Teacher()
		{
			TeacherId = group.Key,
			TeacherName = group.First().TeacherName
		})
		.ToDictionary(x => x.TeacherId);
	var schools = data
		.GroupBy(x => x.SchoolId)
		.Select(group => new School()
		{
			SchoolId = group.Key,
			SchoolName = group.First().SchoolName,
			Teachers = teachersById 
				.Where(kv => data
					.Where(x => x.SchoolId == group.Key)
					.Select(x => x.TeacherId)
					.Contains(kv.Key)
				)
				.Select(x => x.Value)
				.ToList()
		})
		.ToList();
