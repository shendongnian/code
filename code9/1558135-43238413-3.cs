    [AllowOperationsOnly]
    public ActionResult PDFReport(DateTime date)
    {
        return new Rotativa.ViewAsPdf("Report", date);
    }
