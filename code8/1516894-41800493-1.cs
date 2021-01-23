        private Scaling mySliderData;
        public Scaling MySliderData
        {
            get { return mySliderData; }
            set 
            {
                mySliderData = value; 
                NotifyPropertyChanged("MySliderData"); 
            }
        }
