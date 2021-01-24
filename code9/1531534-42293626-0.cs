    using (ZipFile zip = ZipFile.Read(fu.PostedFile.InputStream)){                    
        string extractPath = Server.MapPath("~/Uploads/");
        string oldPathImg = Server.MapPath("~/Uploads/RubbishData/");
        zip.ExtractSelectedEntries("name = *.docx", "",extractPath, ExtractExistingFileAction.OverwriteSilently);
        zip.ExtractSelectedEntries("name = *.png"); // Cannot assign void to a variable, remove the assignment.
    }
