	var schools = data
		.GroupBy(x => x.SchoolId )
		.Select(x => new School()
		{
			SchoolId = x.Key,
			SchoolName = x.First().SchoolName,
			Teachers = data.Where(y => y.SchoolId == x.Key)
				.Select(y => new Teacher()
				{
					TeacherId = y.TeacherId,
					TeacherName = y.TeacherName
				})
				.ToList()
		})
		.ToList();
