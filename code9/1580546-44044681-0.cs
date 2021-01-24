    var IDs =  (from a in db1.Table1 
                join b in db1.Table2 on a.Id equals b.Id 
                where b.Id == 1 && a.Status == "new" 
                select a.Id).Distinct().ToList();
    
    var query = (from c in db2.Company
                where IDs.Contains(c.Id)
                select new { Id = a.Id, CompanyId = c.CompanyId }
             ).OrderByDescending(z => z.CompanyId).ToList();
