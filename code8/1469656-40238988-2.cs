    var result = db.View_VisitorsForm
                   .Where(item => item.VisitingDate >= beginDate && item.VisitingDate < endDate)
                   .GroupBy(G => G.Employee)
                   .Select(e =>new
                   {
                       employee = e.Key,
                       count = e.Count()
                   });
