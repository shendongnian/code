    public sealed partial class MainPage : Page
    {
        ObservableCollection<Book> books = new ObservableCollection<Book>
        {
            new Book { Name = "Name1", Title = "Title1" },
            new Book { Name = "Name2", Title = "Title2" },
            new Book { Name = "Name3", Title = "Title3" },
            new Book { Name = "Name4", Title = "Title4" }
        };
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
