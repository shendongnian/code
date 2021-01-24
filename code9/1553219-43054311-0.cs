        [Table("EMPLOYMENT")]
        public class Employment
        {
            private DateTime _StartDate;
            [Column("STARTDATE")]
            public DateTime StartDate
            {
                get
                {
                    return _StartDate;
                }
                set
                {
                    _StartDate = value;
                    StartMonth = value.ToString("MMMM") ?? null;
                }
            }
            [Column("STARTMONTH")]
            public string StartMonth { get; private set; }
        }
