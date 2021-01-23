    TimeSpan pickerTime = DateTime.Now.TimOfDay;
        ///PROPERTY
        public TimeSpan PickerTime {
            get { return pickerTime; }
            set {
                if(pickerTime != value) {
                    pickerTime = value;
                    OnPropertyChanged("PickerTime");
                }
            }
        }
