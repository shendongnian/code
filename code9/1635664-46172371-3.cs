    public class Grid : INotifyPropertyChanged
    {
        
        public Grid()
        {
            PropertyChanged += OnPropertyChanged;
        }        
        public Circle Circle 
        {
           get { return circle; }
           set {
               circle = value;
               RaisePropertyChanged("Circle");
           }
        }
        private Line line;
        public Line Line 
        {
           get { return line; }
           set
           {
               line = value;
               RaisePropertyChanged("Line");
           }
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Circle")
                // Do something to Line
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var propChange = PropertyChanged;
            if (propChange == null) return;
            propChange(this, new PropertyChangedEventArgs(propertyName));
        }
    }
