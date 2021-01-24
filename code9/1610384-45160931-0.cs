    string name = string.Empty;
    string extn = string.Empty;
    
    if (FileUpload1.HasFile)
    {
    	FileInfo fi = new FileInfo(FileUpload1.FileName);
    	byte[] DocumentContent = FileUpload1.FileBytes;
        name = fi.Name;
        extn = fi.Extension;      
    }
