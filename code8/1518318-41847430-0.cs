    public static bool IsFileLocked(this FileInfo f, int c, int m)
    {
        if (c > m) { return true; }
        FileStream fs = null;
        try
        {
            fs = f.Open(FileMode.Open, FileAccess.Read, FileShare.None);
        }
        catch (IOException)
        {
            Thread.Sleep(500);
            return IsFileLocked(f, c + 1, m);
        }
        finally
        {
            fs?.Close();
        }
        return false;
    }
