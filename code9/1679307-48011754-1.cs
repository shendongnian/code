    public partial class MainPage : ContentPage
    {
        SampleViewModel vm;
    
        public MainPage()
        {
            InitializeComponent();
    
            vm = new SampleViewModel();
            BindingContext = vm;
        }
    }
