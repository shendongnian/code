    [HttpPost, Route("stuff/cars/")]
    public IActionResult Cars2([FromBody] List<FooViewModel> cars)
    {
        // do stuff...
        return View();
    }
