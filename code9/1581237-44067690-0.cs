    public partial class MainWindow : Window
    {
        ObservableCollection<Category> _cats;
        public MainWindow()
        {
            InitializeComponent();
            var db = new MyDbContext();
            System.Windows.Data.CollectionViewSource categoryViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["categoryViewSource"];
            await db.Categories.LoadAsync();
            _cats = new ObservableCollection<Category>(db.Categories.Local);
            categoryViewSource.Source = _cats;
            //...
            var c = new Category { Name = "New Category" };
            db.Categories.Add(c); //add to DbSet
            _cats.Add(c); //add to ObservableCollection
        }
    }
