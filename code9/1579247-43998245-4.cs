    public abstract class TreeViewItemViewModel
    {
        private ICommand _expandedCommand;
        public ObservableCollection<TreeViewItemViewModel> Items { get; } = new ObservableCollection<TreeViewItemViewModel>();
        public ICommand ExpandedCommand => _expandedCommand ?? (_expandedCommand = new RelayCommand(TreeViewItemExpanded));
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
        public DirectoryTreeViewItemViewModel(DirectoryInfo directory)
        {
            Directory = directory;
        }
        public DirectoryInfo Directory { get; }
        protected override void TreeViewItemExpanded()
        {
            OnTreeViewItemExpanded(Directory);
        }
    }
    public class DriveTreeViewItemViewModel : TreeViewItemViewModel
    {
        public DriveTreeViewItemViewModel(DriveInfo drive)
        {
            Drive = drive;
        }
        public DriveInfo Drive { get; }
        protected override void TreeViewItemExpanded()
        {
            OnTreeViewItemExpanded(Drive.RootDirectory);
        }
    }
