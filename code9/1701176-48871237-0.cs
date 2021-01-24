    private bool hasWriteAccessToFolder(string folderPath)
    {
        try
        {
            // Attempt to get a list of security permissions from the folder. 
            // This will raise an exception if the path is read only or do not have access to view the permissions. 
            System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(folderPath);
            return true;
        }
        catch (UnauthorizedAccessException)
        {
            return false;
        }
    }
