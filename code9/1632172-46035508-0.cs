    for (int i = 0; i < Request.Files.Count; i++)
    {
        HttpPostedFile postedFile = Request.Files[i];
        if (postedFile.ContentLength > 0)
        {
            string fileName = Path.GetFileName(postedFile.FileName);
            string extension = Path.GetExtension(postedFile.FileName);
            if (fileName.Contains("-b") || fileName.Contains("-B"))
            {
                dt.Rows.Add(fileName.ToLower().Replace("-b", ""));
            }
            if (fileName.Contains("-t") || fileName.Contains("-T"))
            {
                dt1.Rows.Add(fileName.ToLower().Replace("-t", ""));
            }
        }
    }
