    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableView : ContentPage
    {
        public string Receivename { get; set; }
        public TableView()
        {
            InitializeComponent();
            BindingContext = this; //Need to set data context as well, if not defined in XAML
            Receivename = "Hello";
        }
    }
