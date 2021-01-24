    public class MainViewModel : ViewModelBase
    {
        private BloodTypeEnum _bloodType;
        public BloodTypeEnum BloodType
        {
            get { return _bloodType; }
            set
            {
                _bloodType = value;
                RaisePropertyChanged();
            }
        }
    }
