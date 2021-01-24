        private SeriesCollection myPie = new SeriesCollection();
        public SeriesCollection MyPie
        {
            get
            {
                return myPie;
            }
            set
            {
                myPie = value;
                RaisePropertyChanged("MyPie");
            }
        }
