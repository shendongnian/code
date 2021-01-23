	var schools = data
		.GroupBy(x => new { x.SchoolId, x.SchoolName })
		.Select(x => new School()
		{
			SchoolId = x.Key.SchoolId,
			SchoolName = x.Key.SchoolName,
			Teachers = data.Where(y => y.SchoolId == x.Key.SchoolId)
				.Select(y => new Teacher()
				{
					TeacherId = y.TeacherId,
					TeacherName = y.TeacherName
				})
				.ToList()
		})
		.ToList();
