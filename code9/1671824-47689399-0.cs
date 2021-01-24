    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
    }
