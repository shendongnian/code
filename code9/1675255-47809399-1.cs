    [HttpPost]
    public ActionResult Search(SearchBarcode model, int BarcodeNum)
    {         
        var FoundRecord = db.ChristmasTicketsDb.SingleOrDefault(x => x.BarcodeNum == BarcodeNum);         
    
        if (FoundRecord == null)
        {
            return HttpNotFound();
        }
        return View(FoundRecord);
    }
