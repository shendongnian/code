    public class Pages
    {
        public int PageId { get; set; }
        
        // you need a backing field then you can customize the set and get code
        private string folderName;
        public string FolderName
        {
            get { return this.folderName; }
            // if the fileName can be set to null you'll want to use ?. or you'll get 
            // a null reference exception
            set { this.folderName = value?.Trim(); }
        }
    }
