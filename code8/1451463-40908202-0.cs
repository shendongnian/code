        protected void DownloadFile(FileInfo downloadFile, string downloadFilename, string downloadContentType)
        {
            Byte[] bin = File.ReadAllBytes(downloadFile.FullName); 
            Response.ClearHeaders();
            Response.ClearContent();
            Response.ContentType = downloadContentType;
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", downloadFilename ));
            Response.BinaryWrite(bin);
            Response.Flush();
            Response.SuppressContent = true; 
        }
