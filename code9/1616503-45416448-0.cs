    public ActionResult DownloadFile(string strKey) {
        GetObjectResponse resp = Media.ReadS3Object("data", strKey);
        StreamReader sr = new StreamReader(resp.ResponseStream);
        return File(sr, resp.ContentType, fname);
    }
