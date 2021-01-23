    public partial class LoginPage : ContentPage
    {
        private LoginViewModel _model;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = _model = new LoginViewModel(this);
        }
        protected override async void OnAppearing() //Notice I changed this to async and can now await the GetEmployees() call
        {
            base.OnAppearing();
            await _model.GetEmployees();
        }
        public ListView MyList
        {
            get
            {
                return mylist;
            }
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem == null) return; 
            await Navigation.PushAsync(new MenuPage());
        }
    }
