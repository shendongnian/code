    public static int E_FAIL = 0x80004005;
    public static int ERROR_FILE_NOT_FOUND = 0x2;
    
    // When the exception is caught
    catch (Win32Exception e)
    {
        if(e.ErrorCode == E_FAIL && e.NativeErrorCode == ERROR_FILE_NOT_FOUND)
        {
        // This is a "File not found" exception
        }
        else
        {
        // This is something else
        }
    }
