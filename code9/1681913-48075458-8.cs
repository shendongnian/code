    public class RestaurantDetailsViewModel : INotifyPropertyChanged
    {
        Service _services = new Service();
        Restaurant restaurant;
        public RestaurantDetailsViewModel(Restaurant restaurant)
        {
            this.restaurant = restaurant; // now we can use it in ViewModel
        }
        List<Info> _info;
        public List<Info> Info
        {
            get { return _info; }
            set
            {
                if (value == _info) return;
                _info = value; 
                 OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand GetInfoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    InfoData = await _apiServices.GetInfoData();
                    await  Application.Current.MainPage.Navigation.PushAsync(new  SingleDetailsAboutPrice(restaurant)); // or if you want u can pass only restaurant.restaurantID.
                });
            }
        }
    }
