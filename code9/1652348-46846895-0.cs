    public class ViewModel : PropertyChangedBase
    {
        private _isFeatureAvailable;
            public bool IsFeatureAvailable
        {
            get { return _isFeatureAvailable; }
            set
            {
                _isFeatureAvailable = value;
                NotifyOfPropertyChange(() => IsFeatureAvailable);
            }
        }
    }
