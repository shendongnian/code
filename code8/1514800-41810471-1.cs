    public static void Lock(string filePath)
    {
        var workspace = GetWorkspace(filePath);
        workspace.PendEdit(new[] {filePath}, RecursionType.None, null, LockLevel.Checkin);
    } 
