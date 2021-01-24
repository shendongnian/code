        private DateTime _myVideModelProperty = DateTime.Now;
        public DateTime MyVideModelProperty
        {
            get { return _myVideModelProperty; }
            set
            {
                _myVideModelProperty = value;
                // Don't forget to add your INotify here.
            }
        }
