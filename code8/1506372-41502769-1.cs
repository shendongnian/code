        private double size;
        public double Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                NotifyPropertyChanged ();
                sizeAsString = FormatTheDoubleAccordingYourRequirements (size);
                NotifyPropertyChanged ("SizeAsString");
            }
        }
        private string sizeAsString;
        public string SizeAsString
        {
            get
            {
                return sizeAsString;
            }
            set
            {
                sizeAsString = value;
                Size = ParseTheStringAccordingYourRequirements (sizeAsString);
                NotifyPropertyChanged ();
            }
        }
