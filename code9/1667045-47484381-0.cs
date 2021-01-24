    ret = db.Address.AsNoTracking()
                    .ToList()
                    .Where(a => a.IsProcessed == false && a.IsDeleted == false)
                    .ToList()
                    .Select(aa => new OnlineContactChangeTableModel(aa))
                    .ToList();
