        private long IdProperty;
        public long Id
        {
            get { return IdProperty; }
            set { IdProperty = value; RaisePropertyChanged(() => Id); }
        }
		
		private long NameProperty;
        public long Name
        {
            get { return NameProperty; }
            set { NameProperty = value; RaisePropertyChanged(() => Name); }
        }
