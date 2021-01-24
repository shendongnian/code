    public class MyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    
        double totalPrice;
        public double TotalPrice
        {
            get
            {
                return totalPrice;
            }
    
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }
    }
