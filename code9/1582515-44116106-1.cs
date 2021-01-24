     db.Mark.Select(m=> new StudentInfo {
                        StudentID = m.StudentId, 
                        Name = m.Student.Name,
                        Subject = m.Subject,
                        Score = m.Score});
	Expression<Func<StudentInfo, object>> sortExpression = null;
	if (sortColumn == "Name")
	{
		sortExpression = i => i.Name;
	}
	else if (sortColumn == "Subject")
	{
		sortExpression = i => i.Subject;
	}
		query = isAcending
					? query.OrderBy(sortExpression)
					: query.OrderByDescending(sortExpression);
        return query;
