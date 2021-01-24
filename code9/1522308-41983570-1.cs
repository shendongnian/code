    return db.Dept_Emp.GroupBy(d => d.DeprtmentName)
        .Select(g => new Dept_Emp
             {
                 Id = g.First().Id,
                 F_Name =  g.First().F_Name,
                 L_Name =  g.First().L_Name,
                 Gender =  g.First().Gender,
                 DeprtmentName =  g.Key,
                 Sal  = g.Sum(x => x.Sal)
             });
