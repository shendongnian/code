        //your existing code, I will not break it
        public string Date { get; }
        //change group by property to the following
        public DateTime RealDate
        {
            get
            {
                DateTime dt = Convert.ToDateTime(this.Date).Date;
                return dt;
            }
        }
