    using (TransactionScope _ts = new TransactionScope())
    {
      _dbRegn = _db.StudentRegistrations.Where(r => r.Id == Id).FirstOrDefault();
    
      if (_dbRegn != null)
      {                      
        //Remove existing receipts
        foreach (var _existingReceipt in _dbRegn.StudentReceipts.ToList())
        {
          __db.StudentReceipts.Remove(_existingReceipt);
        }                           
    
        //adding new receipt
        foreach (var _receipt in mdlCourseInterchange.StudentReceiptList)
        {
          StudentReceipt _studReceipt = new StudentReceipt();
          //...
          //...
          _db.StudentReceipts.Add(_studReceipt);
        }
        //...
        //..
    
        int j = _db.SaveChanges();
        if (j > 0)
        {
          _ts.Complete();
          return Json(new { message = "success" }, JsonRequestBehavior.AllowGet);
        }
      }
    }
