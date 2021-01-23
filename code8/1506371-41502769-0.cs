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
                SizeAsString = FormatTheDoubleAccordingYourRequirements (size);
                NotifyPropertyChanged ();
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
