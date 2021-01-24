    public class TreeViewFolderViewModel : ViewModelBase
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }
        private ObservableCollection<TreeViewFolderViewModel> children;
        public ObservableCollection<TreeViewFolderViewModel> Children
        {
            get
            {
                return children ?? (children =
                new ObservableCollection<TreeViewFolderViewModel>());
            }
            set { children = value; OnPropertyChanged("Children"); }
        }
    }
    public class TreeViewModel : ViewModelBase
    {
        private List<TreeViewFolderViewModel> items;
        public List<TreeViewFolderViewModel> Items
        {
            get { return items; }
            set { items = value; OnPropertyChanged("Items"); }
        }
        public TreeViewModel()
        {
            Items = new List<TreeViewFolderViewModel>()
            {
                new TreeViewFolderViewModel()
                {
                    Id =0, Text="RootFolder", Children=new ObservableCollection<TreeViewFolderViewModel>()
                    {
                        new TreeViewFolderViewModel() { Id = 10, Text = "FirstFolder", Children=new ObservableCollection<TreeViewFolderViewModel>() { new TreeViewFolderViewModel() { Id = 11, Text = "FirstChild" } } } ,
                        new TreeViewFolderViewModel() { Id = 20, Text = "SecondFolder", Children = new ObservableCollection<TreeViewFolderViewModel>() { new TreeViewFolderViewModel() { Id = 21, Text = "SecondChild" } } } ,
                        new TreeViewFolderViewModel() { Id = 30, Text = "ThirdFolder", Children = new ObservableCollection<TreeViewFolderViewModel>() { new TreeViewFolderViewModel() { Id = 31, Text = "ThirdChild" } } }
                    }
                }
            };
        }
    }
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
