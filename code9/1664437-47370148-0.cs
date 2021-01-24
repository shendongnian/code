    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (fuImage.HasFiles)
        {
            foreach (HttpPostedFile file in fuImage.PostedFiles) //be explicit
            //Note that var file is HttpPostedFile
            {
                UploadFile("Images",file); //not fuImage
            }
        }
    }
    
    private void UploadFile(string FolderName, HttpPostedFile fu)//FileUpload gives single file
    {
        string FolderPath = "~/" + FolderName; // \\ is not the best choice
        //your remaining code works and is skipped for brevity
    }
