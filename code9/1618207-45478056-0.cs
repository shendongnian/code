    try
    {
        File.Delete(strFilePath);
    }
    catch (DirectoryNotFoundException ex)
    {
        //File not found
    }
    catch (IOException ex)
    {
        //File in use
    }
    catch (UnauthorizedAccessException ex)
    {
        //Access denied
    }
