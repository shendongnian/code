      public ActionResult EditItem(H_Table item)
        {
          db_connection.Entry<YourTableNameFromdbContext>(item).State = EntityState.Modified;
          db_connection.SaveChanges();
          return RedirectToAction("Index");
        }
