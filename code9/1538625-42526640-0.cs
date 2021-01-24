    var model = _db.Tickets
                .Join(_db.Cust,
                    t => t.Id,
                    w => w.cust_id,
                    (t, w) => new { Tks = t, Custs = w })
                .Where(t => t.Tks.Id == 5).OrderByDescending(w => w.Tks.Id)
                .GroupBy(t => t.Tks.Name).ToList()
                .Select(x => new tks_custs //here you creating your ViewModel
                {
                    Tks = x.FirstOrDefailt().Tks,
                    Custs = x.FirstOrDefailt().Custs 
                });
