    public class Grid
    {
        private Circle circle;
        public Circle Circle 
        {
           get { return circle; }
           set 
           {
               circle = value;
               if (circle != null) 
                  circle.PropertyChanged += OnPropertyChanged;
           }
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Radius")
                // Do something to Line
        }
    }
