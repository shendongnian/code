    namespace sample.Models
    {
        public class Pages
        {
            public int PageID { get; set; }
            private string folderName;
            public string FolderName 
            { 
                get { return folderName; }
                set { folderName = value.Trim(); }
            }
        }
    }
