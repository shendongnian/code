    string zipFileName = "ZipName.zip";
    Response.ContentType = "application/zip";
    Response.AddHeader("content-disposition", "fileName=" + zipFileName);
    byte[] buffer = new byte[4096];
    ZipOutputStream zipOutputStream = new ZipOutputStream(Response.OutputStream);
    zipOutputStream.SetLevel(9);     // Point 2
                        
    try
     {
       string cs = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
       foreach (Filec file1 in Files)
        {
         StreamModel model123 = new StreamModel();
         const string SelectTSql = @"SELECT FileData.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT(), FileType
                             FROM MyFiles WHERE FileId = @FileId";
         using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required,
          new TransactionOptions { Timeout = TimeSpan.FromDays(1) })) // Point 3
            {
             using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(cs))
              {
                conn.Open();
              using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(SelectTSql, conn))
               {
                 cmd.Parameters.Add("@FileId", System.Data.SqlDbType.Int).Value = Convert.ToInt32(file1.FileId);
               using (System.Data.SqlClient.SqlDataReader rdr = cmd.ExecuteReader())
                {
                  rdr.Read();
                  model123.serverPath = rdr.GetSqlString(0).Value;
                  model123.serverTxn = rdr.GetSqlBinary(1).Value;
                  model123.filetype = rdr.GetSqlString(2).Value;
                  rdr.Close();
                }
               }
              }
          using (System.Data.SqlTypes.SqlFileStream sfs = new System.Data.SqlTypes.SqlFileStream(model123.serverPath, model123.serverTxn, FileAccess.Read))
            {
              ZipEntry zipEntry = new ZipEntry(ZipEntry.CleanName(file1.FileName));
              zipEntry.Size = sfs.Length;      // Point 1
              zipOutputStream.PutNextEntry(zipEntry);
              int bytesRead;
              while ((bytesRead = sfs.Read(buffer, 0, buffer.Length)) > 0)
               {
                if (!Response.IsClientConnected)
                  {
                      break;
                  }
                zipOutputStream.Write(buffer, 0, bytesRead);
                Response.Flush();
               }
                 sfs.Close();
             }
    
        ts.Complete();
      }
        zipOutputStream.CloseEntry();
     }
    
      zipOutputStream.Finish();
      zipOutputStream.Close();
      Response.Flush();
      Response.End();
    }
    catch (Exception ex)
     {
       TempData["ErrorMessage"] = "Oohhhh! Exception Occured(Error)...";
     }
