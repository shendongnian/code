        internal DateTime databaseDateTime { get; set; }
        public DateTime MyDateTimeWithoutMs 
        {
            get
            {
                return databaseDateTime.DateTimeWithoutMs();
            }
            set
            {
                databaseDateTime= value.ToDateTimeWithoutMs();
            }
        }
