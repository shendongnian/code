    public class MyViewModel : MvxViewModel
    {
        private ISettings _settings;
        
        public MyViewModel(ISettings settings)
        {
            _settings = settings;
        }
    
        public string FacebookId => _settings.GetValue("USER_FACEBOOK_ID", string.Empty);
    }
