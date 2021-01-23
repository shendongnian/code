     MemoryStream mybuffer= New MemoryStream(File.ReadAllBytes(filename));
     Response.Clear();
      Response.ClearHeaders();
      Response.ClearContent();
                    //this puts the response to a page
      Response.ContentType = "application/" + "octet-stream";
      Response.AddHeader("Content-disposition", "attachment; filename=" + filename); 
      Response.AddHeader("Content-Length", mybuffer.Length.ToString());
      Response.BinaryWrite(mybuffer);
      Response.Flush();
      Response.Close();
       Response.End();
