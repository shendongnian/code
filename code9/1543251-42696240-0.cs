        var query = departments.GroupJoin(students,
                       dp => dp.DNO, st => st.DNO,
                       (dept,studs) => new
                           {
                               DName = g.Key,
                               Count = g.Count()
                           });
