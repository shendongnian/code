      if(item.BatchId == null)
      {
        dbEntity.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        dbEntity.SaveChanges();
      }
      item.StockAvailable = lines.StockAvailable - lines.PickedStock;
      dbEntity.Entry(picklistline).State = System.Data.Entity.EntityState.Modified;
      dbEntity.Entry(item).State = System.Data.Entity.EntityState.Added;
      dbEntity.SaveChanges();
      return View();
