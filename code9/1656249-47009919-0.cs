    public bool fileIsOpen(string path)
    {
        System.IO.FileStream a = null;
    
        try
        {
            a = System.IO.File.Open(path,
            System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
            return false;
        }
        catch (System.IO.IOException ex)
        {
            return true;
        }
    
        finally
        {
            if (a != null)
            {
                a.Close();
                a.Dispose();
            }
        }
    }
