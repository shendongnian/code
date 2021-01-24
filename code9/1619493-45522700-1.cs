    public ActionResult GetHeader()
    {
         ViewBag[SomeConstantStringValue] = "test-class";
         return PartialView("~/Views/Shared/_HeaderLayout.cshtml");
    }
