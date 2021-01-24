    if (Session["UploadedFileNames"] != null)
    {
        Session["UploadedFileNames"] = new List<string>() { fileName };           
    }
    else
    {
        var list = (Session["UploadedFileNames"] as List<string>);
        list.Add(fileName);
        Session["UploadedFileNames"] = list;
    }
