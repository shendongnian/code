    if (ModelState.IsValid) {
      if (addingNewRow) {
        TimeTable tt = new TimeTable {
         // Populate properties (except identity columns)
        };
        db.TimeTables.Add(tt);
      } else {
        // update
      }
      db.SaveChanges();
    }
