      if(item.BatchId == null)
      {
        dbEntity.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        dbEntity.SaveChanges();
        dbEntity.Entry(item).State = System.Data.Entity.EntityState.Added;
      }
      else
      {
        dbEntity.Entry(item).State = System.Data.Entity.EntityState.Modified;
      }
      item.StockAvailable = lines.StockAvailable - lines.PickedStock;
      dbEntity.Entry(picklistline).State = System.Data.Entity.EntityState.Modified;      
      dbEntity.SaveChanges();
      return View();
