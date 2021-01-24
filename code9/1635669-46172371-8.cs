    public class Circle : INotifyPropertyChanged
    {
        private int radius;       
        public int Radius 
        {
            get { return radius; }
            set 
            {
                radius = value;
                RaisePropertyChanged("Radius");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var propChange = PropertyChanged;
            if (propChange == null) return;
            propChange(this, new PropertyChangedEventArgs(propertyName));
        }
    }
