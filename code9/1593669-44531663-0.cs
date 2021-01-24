    public void DownloadFile()
    {
        using (var fs = System.IO.File.Open(filePath, FileMode.Open)) {
             //open saved doc
             using (MemoryStream ms = new MemoryStream())
             {
                fs.CopyTo(ms);
                Response.AddHeader("content-disposition",
                  "attachment;" + "filename=" + fileName + ".docx");
                Response.OutputStream.Write(ms.GetBuffer(), 0, 
                     ms.GetBuffer().Length);
                ms.Flush();
            }
        }
    }
