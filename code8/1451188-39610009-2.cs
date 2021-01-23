    var userList = grouping.Select(q => new {
        UserName = q.FirstOrDefault().UserName,
        Hours = q.Sum(hr => hr.HoursEntered),
        Holiday = q.FirstOrDefault().User.Absences.Where(a => a.AbsenceTypeID == 1 && a.DateEntity.Month == today.Month && a.DateEntity.Year == today.Year).Count(),
    });
