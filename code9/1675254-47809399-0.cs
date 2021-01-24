    [HttpPost]
    public ActionResult Search(SearchBarcode model, int BarcodeNum)
    {         
        var FoundRecord = db.ChristmasTicketsDb.Where(x => x.BarcodeNum == BarcodeNum).Single();     
    
    
        if (FoundRecord == null)
        {
            return HttpNotFound();
        }
        return View(FoundRecord);
    }
