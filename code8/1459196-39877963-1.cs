     public ActionResult Create() 
     {
         db.ValueStreamProduct.Add(vsp); db.SaveChanges();
         // getting last inserted record's Id from ValueStreamProduct table.
         tbl2.Column = vsp.Id
         db.tbl.Add(tbl2);
         db.tbl.Add(tbl2);
         db.SaveChanges();
      }
