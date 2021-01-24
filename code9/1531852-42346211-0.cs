    var list = this.Stocks.Where(x => x.StockType == StockTypeEnum.RawMaterialEntered)
        .GroupBy(i => 
            new { RawMaterialId = i.RawMaterial.Id, RawMaterial = i.RawMaterial.Name })
        .Select(g => new StockSummary
        {
            TotalAmount = g.Sum(i => i.Amount),
            ComponentId = g.Key.RawMaterialId,                   
            Component = g.Key.RawMaterial,
            Suppliers = g
                .SelectMany(s => 
                    s.RawMaterial.SupplierInfos.Select(j => 
                        new { Id = j.Supplier.Id, Name = j.Supplier.Name }))
                .Distinct()
                .Select(h => new StockItemModel() { Id = h.Id, Name = h.Name })
                .ToList()
        })
        .OrderByDescending(g => g.Component).ToList();
