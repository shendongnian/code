    public class TreeItem: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class FolderItem:TreeItem
    {
        public FolderItem()
        {
            Elems = new ObservableCollection<TreeItem>();
        }
        #region:PrivateVariables
        private DirectoryInfo _Info;
        private ObservableCollection<TreeItem> _Elems;
        #endregion
        public DirectoryInfo Info
        {
            get { return _Info; }
            set
            {
                _Info = value;
                OnPropertyChanged("Info");
            }
        }
        public ObservableCollection<TreeItem> Elems
        {
            get { return _Elems; }
            set
            {
                _Elems = value;
                OnPropertyChanged("Elems");
            }
        }
    }
    public class FileItem : TreeItem
    {
        #region:PrivateVariables
        private FileInfo _Info;
        #endregion
        public FileInfo Info
        {
            get { return _Info; }
            set
            {
                _Info = value;
                OnPropertyChanged("Info");
            }
        }
    }
