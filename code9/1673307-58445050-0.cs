    public ActionResult GetPublicLink()
     {
             path = @"D:\Read\x.pdf";
            return new PhysicalFileResult(path, "application/pdf");
    }
