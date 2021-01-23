    foreach (var item in query.ToList()) // --> here the source should be IEnumerable collection
    {
        var PK = db.YearCourse_105008.Find(item.O_GUID);
        PK.Day = Day;
        PK.RC_MAJORCODE = st[i];
        PK.Lesson = i.ToString();
        db.Entry(PK).State = EntityState.Modified;
        db.SaveChanges();
    } 
