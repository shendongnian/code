    private void ShowImage(int Index)
    { 
        // create image list if needed (once)
        if (files == null)
        { 
            files = new DirectoryInfo(picPath).EnumerateFiles().
                Where(q => imgExts.Contains(q.Extension.ToLowerInvariant())).
                Select( z => z.FullName);
    
            filesCount = files.Count();
        }
    
        string thisFile = files.ElementAt(Index);
    
        // no need to dispose an image if you never create one          
        pb2.ImageLocation = thisFile;
        lblImgName.Text = Path.GetFileName(thisFile);
    }
