    byte[] bin;
    
    using (MemoryStream ms = new MemoryStream())
    {
        using (var zip = new ZipFile())
        {
            foreach (var strFile in allFiles)
            {
                var strFileName = Path.GetFileName(strFile);
                zip.AddFile(strFile, strFile.Replace("\\" + strFileName, string.Empty).Replace(diRoot.FullName, string.Empty));
            }
    
            //save the zip into the memorystream
            zip.Save(ms);
        }
    
        //save the stream into the byte array
        bin = ms.ToArray();
    }
    
    //clear the buffer stream
    Response.ClearHeaders();
    Response.Clear();
    Response.Buffer = true;
    
    //set the correct contenttype
    Response.ContentType = "application/zip";
    
    //set the filename for the zip file package
    Response.AddHeader("content-disposition", "attachment; filename=\"" + archiveName + "\"");
    
    //set the correct length of the data being send
    Response.AddHeader("content-length", bin.Length.ToString());
    
    //send the byte array to the browser
    Response.OutputStream.Write(bin, 0, bin.Length);
    
    //cleanup
    Response.Flush();
    HttpContext.Current.ApplicationInstance.CompleteRequest();
