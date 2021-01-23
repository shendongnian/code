    List<StockItem> stockItems = new List<StockItem>
    {
        new StockItem
        {
            StockName ="A",
            Id = 1,
            Warehouses = new List<Warehouse>
            {
                new Warehouse { Id = 1, WarehouseName = "x" },
                new Warehouse { Id = 2, WarehouseName = "y" }
            }
        },
        new StockItem
        {
            StockName = "B",
            Id = 2,
            Warehouses = new List<Warehouse>
            {
                new Warehouse { Id = 3, WarehouseName = "z" },
                new Warehouse { Id = 4, WarehouseName = "w" }
            }
        }
    };
