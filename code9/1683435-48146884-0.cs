    DateTime dtFrom = DateTime.Now;
    var Resignuser = db.Employees.Where((m => (
                    && !m.IsDeleted && m.IsActive
                    && m.IsResign == true
                    && SqlFunctions.DateAdd("month",2,m.ResignLastDate)  >= dtFrom
                    && m.StatusId != 3
                    && m.StatusId != 4)))
                     .Select(m => new
                     {
                         Display = m.FirstName + " " + m.LastName,
                         GUID = m.GUID
                     }).ToList();
