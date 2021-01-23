    var result = db.View_VisitorsForm.GroupBy(G => G.Employee)
                                   .Select(e =>new
                                   {
                                       employee = e.Key,
                                       count = e.Count()
                                   });
