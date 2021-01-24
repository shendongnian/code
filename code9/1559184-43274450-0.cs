    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly SqliteDbContext context;
        private readonly List<Post> _allPosts;
        public MainWindowViewModel()
        {
            context = new SqliteDbContext();
            _allPosts = context.Posts.Include(p => p.Blog).ToList();
            _posts = _allPosts;
            Urls = _allPosts.Where(p => p.Blog != null && !string.IsNullOrEmpty(p.Blog.Url)).Select(p => p.Blog.Url).ToList();
        }
        private List<Post> _posts;
        public List<Post> Posts
        {
            get { return _posts; }
            set { _posts = value; NotifyPropertyChanged(); }
        }
        public List<string> Urls { get; set; }
        private string  _url;
        public string  Url
        {
            get { return _url; }
            set
            {
                _url = value; NotifyPropertyChanged();
                Posts = _allPosts.Where(p => p.Blog != null && p.Blog.Url == _url).ToList();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
