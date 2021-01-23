    public class APIResponseModel
    {
        public string AccountID { get; set; }
        public string CounterSeq { get; set; }
        public string Year { get; set; }
        public string getAllValues
        {
            get
            {
                return AccountID + "-" + CounterSeq + "-" + Year;
            }
        }
        // and/or
        public override string ToString()
        {
            return AccountID + "-" + CounterSeq + "-" + Year;
        }
    }
