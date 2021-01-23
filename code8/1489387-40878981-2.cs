    [HttpPost]
    public ActionResult MyAction() {
        
        Dictionary<String,List<HttpPostedFileBase>> files = UploadUtility.GetFilesAsDictionary( this.Request.Files );
        
        HttpPostedFileBase video = files["videoFile"][0];
        Int32 screenshotCount = files["screenShots"].Count;
        if( screenshotCount > 8 ) {
            this.ModelState.AddModelError( "", "Limit of 8 screenshots at a time." );
            return this.View( new VideModel() );
        }
        
        foreach(HttpPostedFileBase screenshot in files["screenShots"]) {
            // do stuff
        }
    }
