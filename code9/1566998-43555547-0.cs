    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableView : ContentPage
    {
        public string Receivename { get; set; }
        public TableView()
        {
            InitializeComponent();
            Receivename = "Hello";
        }
    }
