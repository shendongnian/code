    .Select(r => {
        var selectedGrades = new List();
        if (r.Grd1 == "Y") selectedGrades.Add("Grd1")
        if (r.Grd2 == "Y") selectedGrades.Add("Grd2")
        ...
        return new TypeWithGradesList{
             ....
             GradesList = string.Join(",", selectedGrades.ToArray())
        }
    })
