    public class UserDirectory
    {
        public ObservableCollection<UserFile> Files { get; set; } = new ObservableCollection<UserFile>();
        public ObservableCollection<UserDirectory> Subfolders { get; set; } = new ObservableCollection<UserDirectory>();
        //  Union demands a non-null argument
        public IEnumerable Items { get { return Subfolders?.Cast<Object>().Union(Files); } }
        public String DirectoryPath { get; set; }
        public String Name { get { return System.IO.Path.GetFileName(DirectoryPath); } }
    }
    public class UserFile
    {
        public String FilePath { get; set; }
        public Category Category { get; set; }
        public String Name { get { return System.IO.Path.GetFileName(FilePath); } }
    }
