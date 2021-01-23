    var rows = students
        .Join(
            studentScores
        ,   st => st.Id
        ,   sc => sc.StudentId
        ,   (st, sc) => new { Student = st, Score = sc }
        )
        .GroupBy(p => new { p.Student.Id, p.Score.Subject })
        .Select(g => new {
            Name = g.First().Student.Name
        ,   Subj = g.Key.Subject
        ,   Points = g.Sum(p => p.Score.Points)
        })
        .ToList();
