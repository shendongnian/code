    [HttpPost]
    public ActionResult Summary(List<string> flagsChecked)
    {
        return Json(new { newUrl = Url.Action("Index","Home") });
    }
