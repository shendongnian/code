    public ActionResult  Download()
    {
        string blobURL = GetBlobSasUri("blob name","container name", "connection string");
        return Redirect(blobURL);
    }
