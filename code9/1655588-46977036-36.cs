    public IActionResult Index()
    {
        byte[] contents = FetchPdfBytes();
        Response.AddHeader("Content-Disposition", "inline; filename=test.pdf");
        return File(contents, "application/pdf");
    }
