    public void GetViewFileData(string attachmentID)
    {
        List<DownloadFileInfoViewModel> retDownloadFilesInfo = new List<DownloadFileInfoViewModel>();
        using (var context = this.GetContext())
        {
            retDownloadFilesInfo = context.GetfileData(attachmentID);
        }   
        
        HttpResponse response = HttpContext.Current.Response;
        // Clear the content of the response
        response.ClearContent();
        response.Clear(); 
        response.ContentType = "application/pdf";
        string filename = retDownloadFilesInfo[0].FileName;
        string ext = Path.GetExtension(filename);
        filename = new string(Path.GetFileNameWithoutExtension(filename).Where(ch => char.IsLetterOrDigit(ch)).ToArray()) + ext;
        response.AddHeader("Content-Disposition", "inline; filename=" + fileName);        
        response.BinaryWrite(retDownloadFilesInfo[0].FileData);
        response.Flush(); // this make stream and without it open 
        response.End();
    }   
           
        
