    public class Directory
    {
        public string text { get; set; }
        public string iconCls { get; set; }
        public List<FolderData> folderData { get; set; }
        public List<Directory> items { get; set; }
        public class FolderData
        {
            public string icon { get; set; }
            public string text { get; set; }
        }
        public class Item
        {
            public string text { get; set; }
            public string iconCls { get; set; }
            public List<FolderData> folderData { get; set; }
        }
    }
