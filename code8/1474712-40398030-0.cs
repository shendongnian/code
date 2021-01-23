        var ordersToDelete = deletedOrders.Split(new[] {','},
          StringSplitOptions.RemoveEmptyEntries).Select(x => new Order 
            { 
                Id = int.Parse(x.Trim())
            })
            .ToList();
        ordersToDelete.ForEach(o => 
            entity.Entry(x).State = System.Data.Entity.EntityState.Deleted);
