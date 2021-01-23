    public class Pages
    {
        public int PageID { get; set; }
        private string _folderName;
        public string FolderName 
        { 
            get { return _folderName; } 
            set { _folderName = value.Trim(); }
        }
    }
