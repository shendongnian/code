    public ActionResult thankyou(string item_number, string pp_txn_id)
    {
    
        var photo = db.PayPalTransactions.SingleOrDefault(x => x.RowID == Convert.ToInt32(item_number));
    if(photo != null){
        photo.pp_txn_id = pp_txn_id;
        db.SubmitChanges();
    
    
        var thisPaidPhoto = (from p in db.Photos
                             where p.PhotoId == Convert.ToInt32(item_number)
                             select p).FirstOrDefault();
    
        return View(thisPaidPhoto);
    }
    else
    {
    return View();
    }
    }
