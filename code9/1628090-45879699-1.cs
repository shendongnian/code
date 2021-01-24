    public class LocationViewModel
        : MvxViewModel
    {
        private readonly MvxSubscriptionToken _token;
    
        public LocationViewModel(IMvxMessenger messenger)
        {
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
        }
    
        private void OnLocationMessage(LocationMessage locationMessage)
        {
            Lat = locationMessage.Lat;
            Lng = locationMessage.Lng;
        }
    
        // remainder of ViewModel
    }
