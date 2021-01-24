                ...
                from a in db.Positions
                     join b in db.People 
                     on new { 
                         a.GradeId, 
                         a.SeriesId, 
                         a.CompanyId, 
                         a.PaybandId }
                     equals new { 
                         b.GradeId, 
                         b.SeriesId, 
                         b.CompanyId, 
                         b.PaybandId } into ab
                     from k in ab.DefaultIfEmpty()
                     // you want to count the number of people per position here
                     group k by new { a.GradeId, a.SeriesId, a.CompanyId, a.PaybandId } into g
                     select new { g.Key.GradeId, g.Key.SeriesId, g.Key.CompanyId, g.Key.PaybandId, Count = g.Count(p => p != null) } into counts
                     // at this point you have position info AND people count per position
                     // next, you can do the remaining joins...
                     join c in db.Grades on counts.GradeId equals c.Id
                     join d in db.Series on counts.SeriesId equals d.Id
                     join e in db.Companies on counts.CompanyId equals e.Id
                     join p in db.Paybands on counts.PaybandId equals p.Id
                     // ... and select full data set, including person count, required for the view
                     select new { 
                        CompanyName = e.Name,
                        GradeName = c.Name,
                        SeriesName = d.Name, 
                        PaybandName = p.Name,
                        a.Authorized,
                        Assigned = counts.Count()
                     } into full
                     // one more step here that will help to tackle your second problem (grouping by company name in the view)
                     // you want your data coming into the view be grouped by company name 
                     group full by full.CompanyName into groupByCompany
                     select new { CompanyName = groupByCompany.Key, CompanyItems = groupByCompany.ToList() }
                    ...
