        var query = departments.GroupJoin(students,
                       dp => dp.DNO, st => st.DNO,
                       (dept,studs) => new
                           {
                               DName = dept.DNO,
                               Count = studs.Count()
                           });
