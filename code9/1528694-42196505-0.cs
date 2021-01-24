	public bool DoesPathContainFolders(string path)
	{
        // Double check in case the given path *is* a root drive.
        string parent = Path.GetDirectoryName(path);
        return parent != null && parent != Path.GetPathRoot(path);
	}
