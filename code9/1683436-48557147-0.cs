    DateTime dtFrom = DateTime.Now.AddMonth(2);
    var Resignuser = db.Employees.Where((m => (
                    && !m.IsDeleted && m.IsActive
                    && m.IsResign == true
                    && DbFunctions.TruncateTime(m.ResignLastDate)  >= DbFunctions.TruncateTime(dtFrom)
                    && m.StatusId != 3
                    && m.StatusId != 4)))
                     .Select(m => new
                     {
                         Display = m.FirstName + " " + m.LastName,
                         GUID = m.GUID
                     }).ToList();
