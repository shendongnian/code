     	public class Pages
	    {
		     private string _folderName;
		     public int PageID { get; set; }
		     public string FolderName
		     {
			      get { return _folderName; }
			      set { _folderName = value?.Trim() ?? string.Empty; }
		     }
	}
