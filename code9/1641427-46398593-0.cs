    string path = Server.MapPath("~/Content/files/newPDFFile.pdf");
        WebClient client = new WebClient();
        Byte[] buffer = client.DownloadData(path);
        if (buffer != null)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "PDFfile.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(buffer);
            Response.End();
        }
