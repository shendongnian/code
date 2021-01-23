    [HttpGet]
    [Route("all/{begin:int}/{pageSize:int}/{sortBy:alpha}/{sortOrder:alpha}/{q:alpha}")]
    public IActionResult GetAll(string q, int begin, int pageSize, string sortBy, bool sortOrder)
     {
       return Json(_repository.GetItemsByPage(q, begin, pageSize, sortBy, sortOrder));
     }
