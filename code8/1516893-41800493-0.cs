    public class Scaling :INotifyPropertyChanged
    {
        public double VerticalSliderHeight
        {
            get { return verticalSliderHeight; }
            set 
            { 
               verticalSliderHeight = value;       
               NotifyPropertyChanged("VerticalSliderHeight"); 
            }
        }
        private double verticalSliderWidth;
        public double VerticalSliderWidth
        {
            get { return verticalSliderWidth; }
            set 
            { 
               verticalSliderWidth = value;
               NotifyPropertyChanged("VerticalSliderWidth"); 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        internal void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
