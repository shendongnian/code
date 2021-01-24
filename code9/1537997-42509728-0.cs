    string[] fileEntries = new string[] {};
    try {
        string targetDirectory = Convert.ToString(Dts.Variables["SourceFolderLocation"].Value);
        fileEntries = Directory.GetFiles(targetDirectory, "*.pdf");
        Dts.Variables["FileList"].Value = fileEntries;
    }
    catch (Exeception e) { 
        // handle exception
    }
