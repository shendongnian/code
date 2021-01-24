    [HttpPost]
    public IActionResult Test([FromBody]Person p)
    {
        
        return Json(new
        {
            sEcho = "",
            iTotalRecords = 2,
            iTotalDisplayRecords = 2,
            aaData = ""
        });
    }
