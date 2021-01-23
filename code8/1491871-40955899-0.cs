    public ActionResult Download(int id)
    {
        //get File by fileId
        var file = ........
        byte[] contents = file.Content;
        return File(contents, file.ContentType)
    }
