    List<DirectoryInfo> GetDirectories(DirectoryInfo di, int level, int maxLevel)
    {
        List<DirectoryInfo> exceptionList = new List<DirectoryInfo>();
        foreach (DirectoryInfo directoryInfo in di.GetDirectories("*", SearchOption.TopDirectoryOnly))
        {
            try
            {
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
                if (level + 1 < maxLevel)
                {
                    exceptionList.AddRange(GetDirectories(directoryInfo, level + 1, maxLevel));
                }
            }
            catch (UnauthorizedAccessException)
            {
                exceptionList.Add(directoryInfo);
            }
        }
        return exceptionList;
    }
