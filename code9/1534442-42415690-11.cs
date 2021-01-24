        // _service: Valid, authenticated Drive service
        // _uploadFile: Full path to the file to upload
        // _parent: ID of the parent directory to which the file should be uploaded
    public static Google.Apis.Drive.v2.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, string _descrp = "Uploaded with .NET!")
    {
       if (System.IO.File.Exists(_uploadFile))
       {
           File body = new File();
           body.Title = System.IO.Path.GetFileName(_uploadFile);
           body.Description = _descrp;
           body.MimeType = GetMimeType(_uploadFile);
           body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
           byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
           System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
           try
           {
               FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
               request.Upload();
               return request.ResponseBody;
           }
           catch(Exception e)
           {
               MessageBox.Show(e.Message,"Error Occured");
           }
       }
       else
       {
           MessageBox.Show("The file does not exist.","404");
       }
    }
