    // Create New instance of FileInfo class to get the properties of the file being downloaded
    FileInfo file = new FileInfo(filepath);
    
    // Checking if file exists
    if (file.Exists)
    {                            
        // Clear the content of the response
        Response.ClearContent();
    
        // LINE1: Add the file name and attachment, which will force the open/cance/save dialog to show, to the header
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.Name));
    
        // Add the file size into the response header
        Response.AddHeader("Content-Length", file.Length.ToString());
    
        // Set the ContentType
        Response.ContentType = ReturnFiletype(file.Extension.ToLower());
    
        // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
        Response.TransmitFile(file.FullName);
    
        // End the response
        Response.End();
    }
