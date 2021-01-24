    protected void FileUploadCustomValidator_ServerValidate(object sender, ServerValidateEventArgs args)
    {
        if (fileUpload1.HasFile)
        {
            if (fileUpload1.PostedFile.ContentLength < 4024000) // if file is less than 3.8Mb
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
