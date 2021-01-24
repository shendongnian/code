    public class DataPoint : INotifyPropertyChanged
    {
        private int _value;
        public int X {get;set;}
        public int Y {get;set;}
        public int Value
        {
            get { return _value; }
            set
            {
                if (_value!= value)
                {
                   _value= value;
                   OnPropertyChanged("Value");
                }
            }
        }
        // INotifyPropertyChanged implementation ommitted for brevity
    }
