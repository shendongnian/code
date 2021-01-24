    public class MainViewModel
    {
        public ObservableCollection<TreeViewItemViewModel> Items { get; } = new ObservableCollection<TreeViewItemViewModel>();
        public MainViewModel()
        {
            foreach (var driveInfo in DriveInfo.GetDrives())
            {
                Items.Add(new DriveTreeViewItemViewModel(driveInfo));
            }
        }
    }
    public abstract class TreeViewItemViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ICommand _expandedCommand;
        private bool _isExpanded;
        public string Name { get; }
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                TreeViewItemExpanded();
                _isExpanded = value;
                OnPropertyChanged(nameof(IsExpanded));
            }
        }
        public TreeViewItemViewModel(string name)
        {
            Name = name;
        }
        public ObservableCollection<TreeViewItemViewModel> Items { get; } = new ObservableCollection<TreeViewItemViewModel>();
        protected abstract void TreeViewItemExpanded();
        protected void OnTreeViewItemExpanded(DirectoryInfo info)
        {
            Items.Clear();
            foreach (DirectoryInfo subDir in info.GetDirectories())
            {
                Items.Add(new DirectoryTreeViewItemViewModel(subDir));
            }
        }
    }
    public class DirectoryTreeViewItemViewModel : TreeViewItemViewModel
    {
        public DirectoryTreeViewItemViewModel(DirectoryInfo directory) : base(directory.Name)
        {
            Directory = directory;
            Items.Add(new DirectoryTreeViewItemViewModel(Directory));
        }
        public DirectoryInfo Directory { get; }
        protected override void TreeViewItemExpanded()
        {
            OnTreeViewItemExpanded(Directory);
        }
    }
    public class DriveTreeViewItemViewModel : TreeViewItemViewModel
    {
        public DriveTreeViewItemViewModel(DriveInfo drive) : base(drive.Name)
        {
            Drive = drive;
            Items.Add(new DirectoryTreeViewItemViewModel(Drive.RootDirectory));
        }
        public DriveInfo Drive { get; }
        protected override void TreeViewItemExpanded()
        {
            OnTreeViewItemExpanded(Drive.RootDirectory);
        }
    }
