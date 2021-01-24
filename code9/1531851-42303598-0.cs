            var list = stocks
                .GroupBy(i => new { RawMaterialId = i.RawMaterial.Id, RawMaterial = i.RawMaterial.Name,
                    Suppliers = i.RawMaterial.SupplierInfos.Select(j => new { Id = j.Supplier.Id, Name = j.Supplier.Name })
                })
                .Select(g => new
                {
                    TotalAmount = g.Sum(i => i.Amount),
                    ComponentId = g.Key.RawMaterialId,
                    Component = g.Key.RawMaterial,
                    Suppliers = string.Join(",", g.Key.Suppliers.Select(h => new { Id = h.Id, Name = h.Name }).ToList())
                })
                .OrderByDescending(g => g.Component).ToList();
