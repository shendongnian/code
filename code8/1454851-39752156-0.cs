    /// Download a file
    /// Documentation: https://developers.google.com/drive/v2/reference/files/get
    /// 
    
    /// a Valid authenticated DriveService
    /// File resource of the file to download
    /// location of where to save the file including the file name to save it as.
    /// 
    public static Boolean downloadFile(DriveService _service, File _fileResource, string _saveTo)
    {
    
    if (!String.IsNullOrEmpty(_fileResource.DownloadUrl))
    {
    try
    {
    var x = _service.HttpClient.GetByteArrayAsync(_fileResource.DownloadUrl );
    byte[] arrBytes = x.Result;
    System.IO.File.WriteAllBytes(_saveTo, arrBytes);
    return true; 
    }
    catch (Exception e)
    {
    Console.WriteLine("An error occurred: " + e.Message);
    return false;
    }
    }
    else
    {
    // The file doesn't have any content stored on Drive.
    return false;
    }
    }
