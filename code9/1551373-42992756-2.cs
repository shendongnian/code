        /// <summary>
        /// getter and setter
        /// </summary>
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
            }
        }
