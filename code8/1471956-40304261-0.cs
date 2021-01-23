    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double lowerValue;
        public double LowerValue
        {
            get { return lowerValue; }
            set
            {
                if (value <= upperValue)
                {
                    lowerValue = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LowerValue"));
                }
            }
        }
        private double upperValue;
        public double UpperValue
        {
            get { return upperValue; }
            set
            {
                if (value >= lowerValue)
                {
                    upperValue = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UpperValue"));
                }
            }
        }
    }
