    [AllowOperationsOnly]
    [Authorize]
    public ActionResult PDFReport(DateTime date)
    {
        return new Rotativa.ActionAsPdf("Report", date);
    }
    [HttpGet]
    [AllowOperationsOnly]
    [Authorize]
    public ActionResult Report(DateTime date)
    {
        // my code...
        return View();
    }
