        result = db.TableA
                    .Select(c => new { SupplierId = c.SupplierID, SupplierName = c.SupplierName })
                    .Union(db.TableB.Select(g => new { SupplierId = (int?)g.SupplierId, SupplierName = g.Name }))
                    .Where(c => c.SupplierId == supplierId)
                    .Select(c => c.SupplierName)
                    .FirstOrDefault();
