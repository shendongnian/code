    public class Folder
    {
      	[JsonProperty(PropertyName = "@odata.id")]
      	public string OdataId { get; set; }
	
		public string Id { get; set; }
		public string DisplayName { get; set; }
		public string ParentFolderId { get; set; }
		public int ChildFolderCount { get; set; }
		public int UnreadItemCount { get; set; }
		public int TotalItemCount { get; set; }
	}
