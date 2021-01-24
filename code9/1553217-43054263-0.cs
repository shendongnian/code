        [NotMapped]
        public string StartMonth
        {
            get
            {
                return StartDate.HasValue ? StartDate.Value.Month.ToString() : null;
            }
        }
