      // Create the service using the client credentials.
        var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "APP_NAME_HERE"
            });
        var uploadStream = new System.IO.FileStream("FILE_NAME",
                                                    System.IO.FileMode.Open,
                                                    System.IO.FileAccess.Read);
        // Get the media upload request object.
        InsertMediaUpload insertRequest = service.Files.Insert(
            new File
            {
                Title = "FILE_TITLE",
            },
            uploadStream,
            "image/jpeg");
    
        // Add handlers which will be notified on progress changes and upload completion.
        // Notification of progress changed will be invoked when the upload was started,
        // on each upload chunk, and on success or failure.
        insertRequest.ProgressChanged += Upload_ProgressChanged;
        insertRequest.ResponseReceived += Upload_ResponseReceived;
    
        var task = insert.UploadAsync();
        task.ContinueWith(t =>
            {
                // Remeber to clean the stream.
                uploadStream.Dispose();
            });
