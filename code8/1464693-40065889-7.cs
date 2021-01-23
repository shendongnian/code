    public ActionResult GetAttachment(Guid noteGuid)
    {
        byte[] content = Convert.FromBase64String(retrievedAnnotation.DocumentBody);
        return System.Web.MVC.File(content, "text/plain", "filename.txt");
    }
