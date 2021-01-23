    var result = _context.Manufacturers
       .Where(m => m.status == 0)
       .Join(_context.Assets.Where(a => a.state == 0), 
             a => a.ManufacturerID,
             m => m.ManufacturerID.ToString(),
            (a,m) => new AssetsDB.ViewModels.ManufacturerIndexViewModel
                     {
                             ManufacturerID = m.ManufacturerID,
                             Description = m.Description,
                             Count = m.Count()
                     }
       )
       .ToList();
                
