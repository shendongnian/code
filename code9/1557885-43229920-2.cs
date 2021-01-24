    public class NewProductCount : INotifyPropertyChanged
    {
        private string _sUnits;
        private string _pUnits;
        public string SellingUnits
        {
            get
            {
                return _sUnits;
            }
            set
            {
                _sUnits = value;
                _pUnits = string.Empty; //do something dumb just to show the bindings are updating...
                NotifyPropertyChanged();
                NotifyPropertyChanged("PackingUnits"); //nameof/reflection/whatever you want to use to pass this property name through.
            }
        }
        public string PackingUnits
        {
            get
            {
                return _pUnits; 
            }
            set
            {
                _pUnits = value;
                _sUnits = value; //do something dumb just to show the bindings are updating...
                NotifyPropertyChanged();
                NotifyPropertyChanged("SellingUnits"); 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
