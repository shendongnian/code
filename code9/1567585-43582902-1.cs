          public ActionResult EditItem(H_Table item)
            {
                H_Table oldObj= db.H_Table.Find(item.ID);
                db.Entry(oldObj).CurrentValues.SetValues(item);
                db_connection.SaveChanges();
                return RedirectToAction("Index");
            }
