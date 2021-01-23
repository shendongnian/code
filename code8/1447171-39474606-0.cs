    var query = from c in db.Companies
                select new CompanySummary
                {
                    Name = c.Name,
                    EmpCount = c.Employees.Count(),
                    ConCount = c.Contractors.Count(),
                };
