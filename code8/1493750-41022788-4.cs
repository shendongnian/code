    public sealed partial class MainPage : Page
    {
        public MainCategoryModel model;
        public MainPage()
        {
            model = new MainCategoryModel();
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            model.Clear();
            model.myList.Add(new PageInput() {Name = "testName"});
        }
