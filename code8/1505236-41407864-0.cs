    var query = db.Course.Select(c => new
    {
        CourseId = c.Id,
        CourseName = c.Name,
        NumberOfTutionCenters = db.Course_TutionCenter
            .Count(tc => tc.CourseId == c.Id),
        NumberOfStudents = db.CourseStudent
            .Count(s => s.Course_TutionCenter.CourseId == c.Id),
    };
