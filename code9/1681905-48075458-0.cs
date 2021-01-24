    XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Restaurant : ContentPage
    {
        public Restaurant(List<Models.Restaurant> restaurant)
        {
            InitializeComponent();
            NavigationPage.SetTitleIcon(this, "icon.png");
            restaurantlistview.ItemsSource = restaurant;
        }
        private async void restaurantlistview_ItemSelected(object sender,   SelectedItemChangedEventArgs e)
        {
        await Navigation.PushAsync(new RestaurantSinglePageDetails());
        }
    }
