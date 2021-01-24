    dynamic query = (from a in db.Companies
                        join b in db.Positions on a.Id equals b.CompanyId
                        join c in db.Series on b.SeriesId equals c.Id
                        join d in db.Grades on b.GradeId equals d.Id
                        join e in db.People on new { b.CompanyId, b.SeriesId, b.GradeId } equals new { e.CompanyId, e.SeriesId, e.GradeId }
                        group a by new { CompanyName = a.Name, GradeName = d.Name, SeriesName = c.Name, b.Authorized } into f
                        select new { Company = f.Key.CompanyName, Grade = f.Key.GradeName, Series = f.Key.SeriesName, Authorized = f.Key.Authorized, Assigned = f.Count()}).AsEnumerable().Select(r => r.ToExpando());
