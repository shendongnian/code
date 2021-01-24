    [HttpGet]
    public ActionResult Create()
    {
        int ProductId, StatusId;
        
        TempData.Keep("ProductId"); // These two lines will keep data
        TempData.Keep("StatusId");  // upon multiple refreshes
        int.TryParse(TempData["ProductId"].ToString(), out ProductId);
        int.TryParse(TempData["StatusId"].ToString(), out StatusId);
        model.ProductId = ProductId;
        model.StatusId= StatusId;
    
        return View("OrderCreate", model);
    }
