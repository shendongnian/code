    FileInfo file = new FileInfo(GetDocumentUploadFolder(ID) + fileName);
    string strFolder = Server.MapPath(LocalLocation);
    string strDestination = Server.MapPath(LocalLocation + "\\" + fileName);
    // Checking if file exists
    if (file.Exists)
    {
        if (!Directory.Exists(strFolder))
			Directory.CreateDirectory(strFolder);
		// Delete contents in this folder
		Common.DeleteFiles(strFolder, "*.*");
		file.CopyTo(strDestination, true);
	
        // Clear the content of the response
        this.Page.Response.ClearContent();
        // Clear the header of the response
        this.Page.Response.ClearHeaders();
        // Set the ContentType
        this.Page.Response.ContentType = "application/pdf";
        // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
        this.Page.Response.TransmitFile(strDestination);
        // End the response
        this.Page.Response.End();
    }
