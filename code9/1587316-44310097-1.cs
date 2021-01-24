    namespace XamarinTest
    {
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                this.InitializeComponent();
                this.AllTestViewModel = new RecordingViewModel();
                this.BindingContext = AllTestViewModel;                
            }
            public RecordingViewModel AllTestViewModel { get; set; }
        }
    }
