    public JsonResult GetAllBankList()
    {
       db.Configuration.ProxyCreationEnabled = false;
       var bankList = db.Banks.ToList();
       return Json(bankList, JsonRequestBehavior.AllowGet);
    }
