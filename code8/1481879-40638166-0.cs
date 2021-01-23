    public ActionResult ConfirmHire2 (bool userConfirmed, int confirId)
    {
        int Wid = cm.GetCleanerIdFromSale(confirId);
        int Uid = um.GetUserIdFromSale(confirId);
        // Use C#6 `nameof` API for compile time validation of your `RedirectToAction` call
        return RedirectToAction(nameof(Rate), new { Wid = Wid, Uid = Uid });
    }
    public ActionResult Rate(int Wid, int Uid)
    { 
    }
        
