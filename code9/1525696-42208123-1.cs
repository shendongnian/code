    // Summary:
    //     Specifies that the operating system should create a new file. If the file
    //     already exists, it will be overwritten. This requires System.Security.Permissions.FileIOPermissionAccess.Write
    //     permission. FileMode.Create is equivalent to requesting that if the file
    //     does not exist, use System.IO.FileMode.CreateNew; otherwise, use System.IO.FileMode.Truncate.
    //     If the file already exists but is a hidden file, an System.UnauthorizedAccessException
    //     exception is thrown.
    Create = 2,
