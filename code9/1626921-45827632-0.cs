    public class ImageViewModel : INotifyPropertyChaged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int state = 0;
        public int State 
        { 
            set
            {
                this.state = value;
                this.OnPropertyChanged("State");
                this.OnPropertyChanged("CurrentBitmap");
            }
            get
            {
                return this.state;
            }
        }
        public Bitmap SelectedBitmap
        {
            get
            {
                if(this.state = 0)
                    return Bitmap1; //You have to add the logic for Bitmap1
                else if(this.state = 1)
                    return Bitmap2; //You have to add the logic for Bitmap1
                else if(this.state = 2)
                    return Bitmap3; //You have to add the logic for Bitmap1
                else if(this.state = 3)
                    return Bitmap4; //You have to add the logic for Bitmap1
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
