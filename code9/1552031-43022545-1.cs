    public class MyInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ...
            ObservableCollection<MyInfo> items = new ObservableCollection<MyInfo>();
            items.Add(new MyInfo() { Code = "mycode1", Name = "myname1", Country = "mycountry1" });
            items.Add(new MyInfo() { Code = "mycode2", Name = "myname2", Country = "mycountry2" });
            items.Add(new MyInfo() { Code = "mycode3", Name = "myname3", Country = "mycountry3" });
            myListView.ItemsSource = items;
        }
    }
