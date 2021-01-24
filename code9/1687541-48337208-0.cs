            var q =
            from o in _context.Set<Order>()
                join ib in _context.Set<InstalledBase>() on o.InstalledBaseID equals ib.ID
                join c in _context.Set<Company>() on ib.OwnerCompanyID equals c.ID
            let t = new
            {
                o.InstalledBaseID,
                o.Value,
                c.ID,
                c.Name
            }
            group t by new { t.ID, t.Name } into g
            select new
            {
                CompanyId = g.Key.ID,
                Name = g.Key.Name,
                CompanyTotal = g.Sum(f => f.Value)
            };
            var r = q.ToList();
