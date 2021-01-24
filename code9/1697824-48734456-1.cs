    public partial class MainPage : ContentPage
    {
        private MyGameOverviewViewModel _viewModel = new MyGameOverviewViewModel();
        public MainPage()
        {
            BindingContext = _viewModel;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadData();
        }
    }
