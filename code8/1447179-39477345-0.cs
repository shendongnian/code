    var availableWarehouses = new [] { 
        new Warehouse { 
            WarehouseName = "Warehouse1",
            Id = 1
        },
        new Warehouse {
            WarehouseName = "Warehouse2",
            Id = 2
        },
        new Warehouse {
            WarehouseName = "Warehouse3",
            Id = 3
        }
    };
		
    var stocks = new [] {
        new StockItem {
            StockName = "StockCode1",
            Id = 1,
            Warehouses = new List<Warehouse> { availableWarehouses[0], availableWarehouses[1], availableWarehouses[2] }
        },
		new StockItem {
            StockName = "StockCode2",
            Id = 2,
            Warehouses = new List<Warehouse> { availableWarehouses[0], availableWarehouses[1] }
		},
		new StockItem {
			StockName = "StockCode3",
			Id = 3,
			Warehouses = new List<Warehouse> { availableWarehouses[0], availableWarehouses[2] }
		}
    };
		
    var flatten = stocks.Select(item => new {
            StockName = item.StockName,
    		WarehousesNames = availableWarehouses.Select(warehouse => item.Warehouses.Contains(warehouse) ? warehouse.WarehouseName : "          ")
                .Aggregate((current, next) => current + "\t" + next)
		});
    foreach(var item in flatten) {
        Console.WriteLine("{0}\t{1}", item.StockName, item.WarehousesNames);
    }
