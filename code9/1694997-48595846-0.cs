    public ActionResult File(string fileName)
    {
        var path = System.Web.HttpContext.Current.Server.MapPath("~/files/" + fileName);
        var fileStream = new FileStream(path,
            FileMode.Open,
            FileAccess.Read
        );
        var fsResult = new FileStreamResult(fileStream, "application/pdf");
        return fsResult;
    }
