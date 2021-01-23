    [HttpPost]
    [Route("update")]
    public IActionResult Update(Auction item)
    {
        string LocalVariable = HttpContext.Session.GetString("item_id");
        System.Console.WriteLine("?????????????");
        System.Console.WriteLine( LocalVariable);
        System.Console.WriteLine("?????????????");
        var intParse = Int32.Parse(LocalVariable);
        return RedirectToAction("LookUpItem",new {id = intParse});
    }
