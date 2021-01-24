    var list = this.RawMaterials
        .Where(rm =>
            rm.Stocks.Any(s => s.StockType == StockTypeEnum.RawMaterialEntered))
        .Select(rm => new StockSummary
        {
            TotalAmount = rm.Stocks
                .Where(s => s.StockType == StockTypeEnum.RawMaterialEntered)
                .Sum(s => s.Amount),
            ComponentId = rm.Id,                   
            Component = rm.Name,
            Suppliers = rm.SupplierInfos
                .Select(si =>
                    new StockItemModel()
                    {
                        Id = si.Supplier.Id,
                        Name = si.Supplier.Name
                    })
                .ToList()
        })
        .OrderByDescending(ss => ss.Component).ToList();
