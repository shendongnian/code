    [HttpGet]
    public IHttpActionResult GetAttachment(string id)
    {
        try {
            string mapping = @"\\192.168.3.3\Archieve";
            string sourcedir = @"\Digital\";
            string filename = id + ".pdf";
            string sourceFullPath = mapping + sourcedir + filename;
            byte[] dataBytes = new byte[0];
            // connect to other network using custom credential
            var credential = new NetworkCredential("user", "pass", "192.168.3.3");
            using (new NetworkConnection(mapping, credential)) {
                dataBytes = File.ReadAllBytes(sourceFullPath);
            }
            // write file to local
            string destFullPath = string.Format("{0}/Content/Data//{2}", HttpContext.Current.Server.MapPath("~"), filename);
            File.WriteAllBytes(destFullPath, dataBytes);
            // return the file name, 
            return Ok(filename);
            // then you can view your docs using Google Viewer like this
            // https://docs.google.com/viewer?url=http://[YOUR_SERVER_BASE_URL]/content/data/[FILENAME]
        }
        catch (Exception ex) {
            return Content(HttpStatusCode.PreconditionFailed, ex.Message);
        }
    }
