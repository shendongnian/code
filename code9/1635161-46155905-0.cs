    [HttpPost]
    public ActionResult DownloadCertificate(PostModel inputModel, string content)
    {
        if(!ModelState.IsValid){return Json(new {Success=false,//error descr})}
        //Certificate Download
        const string fileType = "application/pkcs10";
        string fileName = "Certificate" + DateTime.Today.ToString(@"yyyy-MM-dd") + ".csr";
        var fileContent = String.IsNullOrEmpty(contrnt) ? "" : contrnt;
        byte[] fileContents = Encoding.UTF8.GetBytes(fileContent);
        var result = new FileContentResult(fileContents, fileType) { FileDownloadName = fileName };
        return result;
    }
