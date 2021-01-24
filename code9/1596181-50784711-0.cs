    protected void FileUploadCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        if (fileUpload1.HasFile)
        {
            if (fileUpload1.PostedFile.ContentLength > 10240)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }
        }
