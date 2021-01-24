    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
    
            myItems = new List<string> { "item1", "item2", "item3" };
        }
    
        List<string> myItems { get; set; }
    }
