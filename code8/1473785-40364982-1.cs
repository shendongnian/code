    [HttpPost]
    public ActionResult PostFile(HttpPostedFileBase file, int NoteId)  
    {   
        // Your existing code for azure blob access
        CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");
        // make sure to a null check on file parameter before accessing the InputStream
        using (var s = file.InputStream)
        {
           blockBlob.UploadFromStream(s);
        }
        // to do :Return something
    }
