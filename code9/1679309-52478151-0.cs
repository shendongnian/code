    public partial class MainPage : ContentPage
    {
        public PlotModel Model = ExampleGenerator.LineSeries();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
