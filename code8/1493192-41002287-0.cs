    [HttpGet]
    public IHttpActionResult Get()
    {
        Item item = Item.GetTestData();       
        return Json(item);
    }
