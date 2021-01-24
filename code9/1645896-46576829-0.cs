        private DateTime mDate = DateTime.Now;
        public DateTime MDate
        {
            get { return mDate; }
            set
            {
                    mDate = value;
                    OnPropertyChanged("MDate");
        
                    SetDaysInMonth();
            }
    }
