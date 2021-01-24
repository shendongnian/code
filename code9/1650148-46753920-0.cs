    public class MyViewModel : INotifyPropertyChanged
    {
        private double _myStoryboardValueKeyframeA;
        public double MyStoryboardKeyframeA
        {
            get
            {
                return _myStoryboardValueKeyframeA;
            }
            set
            {
                _myStoryboardValueKeyframeA = value;
                OnPropertyChanged("MyStoryboardKeyframeA");
            }
        }
        private TimeSpan _myStoryboardTimeKeyframeA;
        public TimeSpan MyStoryboardTimeKeyframeA
        {
            get
            {
                return _myStoryboardTimeKeyframeA;
            }
            set
            {
                _myStoryboardTimeKeyframeA = value;
                OnPropertyChanged("MyStoryboardTimeKeyframeA");
            }
        }
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        public void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
