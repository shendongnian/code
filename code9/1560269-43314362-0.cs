    var query = (from a in db.Table1 join b in db.Table2 on a.Table1Id equals b.Table2Id);
    var ListOfData = query.Where(a=>a.Table1Id == (param)).ToList();
    
    foreach(var item in ListOfData ){
        var DelRecord = query.Where(a=>a.Table1Id == item.TableId).FirstOrDefault();
        db.Table1.DeleteObject(DelRecord);
        db.SaveChanges();
      }
