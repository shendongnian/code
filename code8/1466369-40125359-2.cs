	var schools = data
		.GroupBy(x => x.SchoolId)
		.Select(group => new School()
		{
			SchoolId = group.Key,
			SchoolName = group.First().SchoolName,
			Teachers = data.Where(x => x.SchoolId == group.Key)
				.Select(x => new Teacher()
				{
					TeacherId = x.TeacherId,
					TeacherName = x.TeacherName
				})
				.ToList()
		})
		.ToList();
