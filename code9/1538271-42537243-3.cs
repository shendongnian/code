    private void UploadProgessEvent(Google.Apis.Upload.IUploadProgress obj)
    {
        if (obj.Status == Google.Apis.Upload.UploadStatus.Completed)
        {
            //Succesfully Uploaded
        }
        
        // do updation stuff
    }
