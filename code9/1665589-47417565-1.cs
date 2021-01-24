    var query = db.STUDENT.Where(x => x.STUDENT_CHANGE_IND == null);
    if (!string.IsNullOrEmpty(lastName))
    {
        query = query.Where(x => x.STUDENT_LAST_NAME.StartsWith("Lewis"));
    }
    if (!string.IsNullOrEmpty(firstName))
    {
        query = query.Where(x => x.STUDENT_FIRST_NAME.StartsWith(firstName));
    }
    if (!string.IsNullOrEmpty(spridenId))
    {
        query = query.Where(x => x.STUDENT_ID.Contains(spridenId));
    }
    var y = query.Take(10).ToList();
