    //GET http://example.com/api/test/asjson
    [HttpGet("AsJson")]
    public JsonResult GetAsJson()
    {
        return Json(new Item { Id = 123, Name = "Hero" });
    }
    //GET http://example.com/api/test/withproduces
    [HttpGet("WithProduces")]
    [Produces("application/json")]
    public Item GetWithProduces()
    {
        return new Item { Id = 123, Name = "Hero" };
    }
