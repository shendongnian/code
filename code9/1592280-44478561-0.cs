    class Folder
    {
    	internal readonly Dictionary<string, Folder> SubFolders = new Dictionary<string, Folder>();
	    internal Folder Root = null;
			
		internal string Name;
			
		internal long Size;
			
		internal long GetSum() => Size + SubFolders.Sum(item => item.Value.GetSum());
    }
