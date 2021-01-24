    private void GetFiles()
    {
        DirectoryInfo DIRINF = new DirectoryInfo("C:\\STAIRWAYTOHEAVEN");
        List<FileInfo> FINFO = DIRINF.GetFiles("*.extension").ToList();
        List<object> Data = new List<object>();
        foreach (FileInfo FoundFile in FINFO)
        {
            // do somthing neat here.
            var Name = FoundFile.Name; // Gets the name, MasterPlan.docx
            var Path = FoundFile.FullName; // Gets the full path C:\STAIRWAYTOHEAVE\GODSBACKUPPLANS\MasterPlan.docx
            var Extension = FoundFile.Extension; // Gets the extension .docx
            var Length = FoundFile.Length; // Used to get the file size in bytes, divide by the appropriate number to get actual size.
            // Make it into an object to store it into a list!
            var Item = new { Name = FoundFile.Name, Path = FoundFile.FullName, Size = FoundFile.Length, Extension = FoundFile.Extension };
            Data.Add(Item); // Store the item for use outside the loop.
        }
    }
