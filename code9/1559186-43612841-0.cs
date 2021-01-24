    public class MainWindowViewModel
    {
        private SqliteDbContext context;
        
        public ObservableCollection<Post> Posts { get; set; }
        private string _selectedUrl;
        public ICollectionView PostsView { get; set; }
        public MainWindowViewModel()
        {
            context = new SqliteDbContext();
            Posts = new ObservableCollection<Post>(context.Posts.Include(p => p.Blog));
            PostsView = new CollectionViewSource { Source = Posts }.View;
            PostsView.Filter = post => SelectedUrl == null || SelectedUrl == ((Post)post).Blog.Url;
        }
        
        public string SelectedUrl
        {
            get
            {
                return _selectedUrl;
            }
            set
            {
                _selectedUrl = value;
                PostsView.Refresh();
            }
        }
    }  
