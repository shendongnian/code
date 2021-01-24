		HttpResponse httpResponse = Response;
        httpResponse.Clear();
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        httpResponse.AddHeader("content-disposition", "attachment;filename=" + tName);
        using (MemoryStream memoryStream = new MemoryStream())
        {
            try
            {
                using (FileStream fileStream = new FileStream(fName, FileMode.Open))
                {
                    fileStream.CopyTo(memoryStream);
                }
                memoryStream.WriteTo(httpResponse.OutputStream);
            }
            finally
            {
                memoryStream.Close();
                File.Delete(fName);
            }
        }
        httpResponse.End();
