    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
    	// Get the subdirectories for the specified directory.
    	DirectoryInfo dir = new DirectoryInfo(sourceDirName);
    
    	if (!dir.Exists)
    	{
    		throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
    	}
    
    	if ((dir.Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
    	{
    		// Don't copy symbolic links
    		return;
    	}
    
    	var createdDirectory = false;
    	// If the destination directory doesn't exist, create it.
    	if (!Directory.Exists(destDirName))
    	{
    		var newdir = Directory.CreateDirectory(destDirName);
    		createdDirectory = true;
    	}
    
    	// Get the files in the directory and copy them to the new location.
    	DirectoryInfo[] dirs = dir.GetDirectories();
    	FileInfo[] files = dir.GetFiles();
    	foreach (FileInfo file in files)
    	{
    		if ((file.Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
    			continue; // Don't copy symbolic links
    		
    		string temppath = Path.Combine(destDirName, file.Name);
    		file.CopyTo(temppath, false);
    		CopyMetaData(file, new FileInfo(temppath));
    	}
    
    	// If copying subdirectories, copy them and their contents to new location.
    	if (copySubDirs)
    	{
    		foreach (DirectoryInfo subdir in dirs)
    		{
    			string temppath = Path.Combine(destDirName, subdir.Name);
    			DirectoryCopy(subdir.FullName, temppath, copySubDirs);
    		}
    	}
    
    	if (createdDirectory)
    	{
    		// We must set it AFTER copying all files in the directory - otherwise the timestamp gets updated to Now.
    		CopyMetaData(dir, new DirectoryInfo(destDirName));
    	}
    }
    
    private static void CopyMetaData(FileSystemInfo source, FileSystemInfo dest)
    {
    	dest.Attributes = source.Attributes;
    	dest.CreationTimeUtc = source.CreationTimeUtc;
    	dest.LastAccessTimeUtc = source.LastAccessTimeUtc;
    	dest.LastWriteTimeUtc = source.LastWriteTimeUtc;
    }
