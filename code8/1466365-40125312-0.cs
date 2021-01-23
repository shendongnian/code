	var result = list.GroupBy(x=>new {x.SchoolId, x.SchoolName})
	.Select(x=>
    {
		var s = new School();
		s.SchoolId = x.Key.SchoolId;
		s.SchoolName = x.Key.SchoolName;
		s.Teachers.AddRange(x.Select(
			y => new Teacher{
				TeacherId = y.TeacherId,
				TeacherName = y.TeacherName
			}
		));
		
		return s;
	});
