    foreach (var item in CourseId)
    {
        var cr = new Courses();
        cr.ID = item;
        // Here:
        db.Entry(cr).State = EntityState.Unchanged;
        // or alternatively:
        // db.Courses.Attach(cr);
        rec.course.Add(cr);
    }
    db.Admins.Add(rec);
    db.SaveChanges();
