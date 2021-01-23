    string tempdir1 = Environment.GetSpecialFolder.Temp + "\\tempdir1";
    string tempdir2 = Environment.GetSpecialFolder.Temp + "\\tempdir2";
    Directory.CreateDirectory(tempdir1); 
    Directory.CreateDirectory(tempdir2); 
    try 
    {
        foreach (string filename in Directory.GetFiles(yourdir1, "*.*"))
        {
            File.Move(filename, tempdir1 + Path.GetFilename(filename));
        }
        foreach (string filename in Directory.GetFiles(yourdir2, "*.*"))
        {
            File.Move(filename, tempdir2 + Path.GetFilename(filename));
        }
    } 
    catch (Exception ex)
    {
        // Do the same foreach loops again, but from tempdir to yourdir
        // to move everything back
    }
    finally 
    {
        Directory.DeleteDirectory(tempdir1);    
        Directory.DeleteDirectory(tempdir2);
    }
