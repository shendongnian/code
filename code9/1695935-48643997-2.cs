    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<MyDateVM> items = new List<MyDateVM>();
            items.Add(new MyDateVM { Name = "Test 1", MyDate = new DateTime(2018, 12, 31) }); // first entry
            items.Add(new MyDateVM { Name = "Test 2", MyDate = new DateTime(2019, 1, 6) }); // same week as end of december 2018
            items.Add(new MyDateVM { Name = "Test 3", MyDate = new DateTime(2019, 1, 3) }); // changed order of date
            items.Add(new MyDateVM { Name = "Test 4", MyDate = new DateTime(2019, 1, 9) }); // new week
            items.Add(new MyDateVM { Name = "Test 5", MyDate = new DateTime(2019, 2, 10) }); // long gap, new week
            grid1.DataContext = items;
        }
    }
