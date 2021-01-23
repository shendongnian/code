     public ObservableCollection<Test> TestOC = new ObservableCollection<Test>();
    public MainPage()
    {
        this.InitializeComponent();
        TestOC.Add(new Test() {name="BBB",id="1",Color=new SolidColorBrush(Colors.Red)});
        TestOC.Add(new Test() { name = "CCC", id="11", Color = new SolidColorBrush(Colors.Green) });
        TestOC.Add(new Test() {  name = "AA", id="111", Color = new SolidColorBrush(Colors.Orange) });
        var SortResult = TestOC.OrderBy(a => a.name);           
        ivGridView.ItemsSource =SortResult;
    }
