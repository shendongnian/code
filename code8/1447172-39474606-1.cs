    var query = from c in db.Companies
                select new CompanySummary
                {
                    Name = c.Name,
                    EmpCount = db.Employees.Count(e => e.CompanyId == c.Id),
                    ConCount = db.Contractors.Count(cc => cc.CompanyId == c.Id),
                };
