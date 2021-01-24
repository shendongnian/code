    public class BindablePoint: PropertyChangedBase
    {
        public double X
        {
            get { return Value.X; }
            set { Value = new Point(value,  Value.Y); }
        }
        public double  Y
        {
            get { return Value.Y; }
            set { Value = new Point( Value.X, value); }
        }
        private Point _value;
        public Point Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
                OnPropertyChanged("X");
                OnPropertyChanged("Y");
                if (ValueChanged != null)
                    ValueChanged();
            }
        }
        
        // This property is causing problems for Json.NET
        public Action ValueChanged;
    }
