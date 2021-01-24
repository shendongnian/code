    public class Folder
    {
        public string FolderName { get; set; }
        private ObservableCollection<File> _subFiles;
        public ObservableCollection<File> SubFiles
        {
            get { return _subFiles ?? (_subFiles = new ObservableCollection<File>()); }
            set
            {
                _subFiles = value;
            }
        }
    
        private ObservableCollection<Folder> _subFolder;
        public ObservableCollection<Folder> SubFolders
        {
            get { return _subFolder ?? (_subFolder = new ObservableCollection<Folder>()); }
            set
            {
                _subFolder = value;
            }
        }
    
        public Folder()
        {
    
        }
    }
    public class File
    {
        public string FileName { get; set; }
    }
