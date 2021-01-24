        int i = uploadedFiles.Count;
        List<HttpPostedFile> fileList1 = new List<HttpPostedFile>();
        List<HttpPostedFile> fileList2 = new List<HttpPostedFile>();
        if (i > 0)
        {
            for (int j = 0; j < i/2; j++)
            {
                fileList1.Add(uploadedFiles[j]);
            }
        }
        
        if (i > 0)
        {
            for (int j = i / 2; j < i; j++)
            {
                fileList2.Add(uploadedFiles[j]);
            }
        }
        int filecount = fileList1.Count;
       if (filecount > 0)
        {
            for (int j = 0; j < filecount; j++)
            {
		 string image =  fileList1[j].FileName;
		fileList1[j].SaveAs(imagepath);
		string image =  fileList2[j].FileName;
		fileList2[j].SaveAs(imagepath);
		}
       }
