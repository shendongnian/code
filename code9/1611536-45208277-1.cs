    public class FolderData
    {
        public string Text { get; set; }
        public Image IconCls { get; set; }
    }
    public class Folder
    {
        public string Text { get; set; }
        public Image IconCls { get; set; }
        public List<Folder> Items { get; set; }
        public List<FolderData> FolderDatas { get; set; }
    }
