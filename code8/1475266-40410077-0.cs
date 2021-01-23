    var res buyPostGrades
        .Concat(sellPostGrades)
        .GroupBy(x => new {x.GradeId, x.Name})
        .Select(g => new GradeViewModel {
            GradeId = g.Key.GradeId
        ,   Name = g.Key.Name
        ,   Total = g.Sum(x => x.Total)
        }).ToList();
