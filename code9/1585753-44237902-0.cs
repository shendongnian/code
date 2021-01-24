    foreach (string file in allFiles)
    {
        if (file.Contains(fullname))
        {
            Process.Start(file);
            return;
        }
    }
    foreach (string file in allFiles)
    {
        // if it cant found fullname, try to open by Name only
        if(file.Contains(Name)) 
        {
            Process.Start(file);
            return;
        }
    }
